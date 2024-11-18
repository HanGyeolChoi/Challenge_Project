using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponSO;
    [SerializeField] private LayerMask attackLayer;
    private float timeLastAttack = -30f;
    private Collider2D[] colliders;
    private Transform closestEnemy;
    private SpriteRenderer _renderer;

    private Vector2 direction;
    //private float distance;

    public event Action attackAction;
    private bool isAttacking = false;
    [SerializeField] private LayerMask enemyLayer;

    private void Update()
    {
        //if(aimOption)     // aim option �� ���� ���� �� ���콺 �������� ���� ȸ��
        //{
        //  direction = mouse.position - transform.position;
        //  RotateWeapon();
        //}
        //
        
        colliders = Physics2D.OverlapCircleAll(transform.position, weaponSO.range, attackLayer);        // ��Ÿ� �� �� ���� üũ

        if (colliders.Length <= 0)  // ��Ÿ� �� ���� ���� ��
        {
            return;
        }
        else
        {
            closestEnemy = FindClosestEnemy();
            RotateWeapon();
            if (Time.time - timeLastAttack > weaponSO.attackRate)   
            {
                Attack();
            }
        }
    }

    private Transform FindClosestEnemy()    // ���� ����� �� Transform ��ȯ
    {
        Collider2D col = colliders[0];
        float shortestDist = Vector2.Distance(transform.position, colliders[0].transform.position);
        for (int i = 1; i < colliders.Length; i++)
        {
            if(Vector2.Distance(transform.position, colliders[i].transform.position) < shortestDist)
            {
                col = colliders[i];
                shortestDist = Vector2.Distance(transform.position, colliders[i].transform.position);
            }
        }
        direction = (col.transform.position - transform.position).normalized;
        return col.transform;
    }

    private void RotateWeapon()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        _renderer.flipX = MathF.Abs(angle) > 90f;
    }
    public void Attack()
    {
        timeLastAttack = Time.time;
        attackAction?.Invoke();
        //TODO : ���Ÿ� ����� ����ü �߻�
        isAttacking = true;
    }


    public void AttackToAim(Vector2 aim)
    {
        if (Time.time - timeLastAttack > weaponSO.attackRate)
        {
            timeLastAttack = Time.time;
            attackAction?.Invoke();
            //TODO : ���������� �����ϴ� ��� ����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (weaponSO.type == WeaponType.Melee && isAttacking && Utils.IsLayerMatched(enemyLayer, collision.gameObject.layer))
            // ���� ���Ⱑ �������̰�, ���� �浹 �� �� ������ ����
        {
            //if(collision.gameObject.TryGetComponent<EnemyController>(out EnemyController controller))
            //{
            //      controller.Damage(weaponStat.damage);
            //}
        }
    }

    public void AttackEnd()     // 
    {
        isAttacking = false;
    }
}
