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
    private Transform container;
    private Vector2 direction;
    //private float distance;

    public event Action attackAction;
    private bool isAttacking = false;

    private void Start()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        //container = GetComponentInParent<Transform>(); - Find Transform of container
    }
    private void Update()
    {
        //if(aimOption)     // aim option �� ���� ���� �� ���콺 �������� ���� ȸ��
        //{
        //  direction = mouse.position - transform.position;
        //  RotateWeapon();
        //}
        //

        UpdateWeaponState();
    }

    private void UpdateWeaponState()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, weaponSO.range + 2, attackLayer);        // ��Ÿ� + 2 ���� �� �� ���� üũ

        if (colliders.Length <= 0)  // ��Ÿ� �� ���� ���� ��
        {
            return;
        }
        else
        {
            closestEnemy = FindClosestEnemy();
            RotateWeapon();
            if (CanAttack())
            {
                Attack();
            }
        }
    }

    private Transform FindClosestEnemy()    // ���� ����� �� Transform ��ȯ, direction(���� ����)�� �� ������ ���ϰ� ��
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
        container.rotation = Quaternion.Euler(0, 0, angle);

        _renderer.flipX = MathF.Abs(angle) > 90f;
        _renderer.flipY = _renderer.flipX;
    }
    public void Attack()
    {
        timeLastAttack = Time.time;
        attackAction?.Invoke();
        if(weaponSO.type == WeaponType.Ranged)  //TODO : ���Ÿ� ����� ����ü �߻�
        {
            ShootProjectile();
        }
        
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
        if (weaponSO.type == WeaponType.Melee && isAttacking && Utils.IsLayerMatched(attackLayer, collision.gameObject.layer))
            // ���� ���Ⱑ �������̰�, ���� �浹 �� �� ������ ����
        {
            //if(collision.gameObject.TryGetComponent<EnemyController>(out EnemyController controller))
            //{
            //      controller.Damage(weaponStat.damage);
            //}
        }
    }

    private void ShootProjectile()
    {

    }


    public void AttackEnd()     // 
    {
        isAttacking = false;
    }

    private bool CanAttack()    // ���� ����� ���� �����Ÿ� ���� ���� + ���� ��Ÿ�� ����
    {
        return (Vector2.Distance(transform.position, closestEnemy.position) < weaponSO.range && Time.time - timeLastAttack > weaponSO.attackRate);
    }
}
