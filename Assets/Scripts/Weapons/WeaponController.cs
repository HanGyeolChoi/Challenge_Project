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

    private void Start()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        
    }
    private void Update()
    {
        //if(aimOption)     // aim option 이 켜져 있을 때 마우스 방향으로 무기 회전
        //{
        //  direction = mouse.position - transform.position;
        //  RotateWeapon();
        //}
        //

        UpdateWeaponState();
    }

    private void UpdateWeaponState()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, weaponSO.range, attackLayer);        // 사거리 내 적 유무 체크

        if (colliders.Length <= 0)  // 사거리 내 적이 없을 시
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

    private Transform FindClosestEnemy()    // 가장 가까운 적 Transform 반환, direction(무기 방향)을 그 적에게 향하게 함
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
        //TODO : 원거리 무기는 투사체 발사
        isAttacking = true;
    }


    public void AttackToAim(Vector2 aim)
    {
        if (Time.time - timeLastAttack > weaponSO.attackRate)
        {
            timeLastAttack = Time.time;
            attackAction?.Invoke();
            //TODO : 에임쪽으로 공격하는 기능 구현
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (weaponSO.type == WeaponType.Melee && isAttacking && Utils.IsLayerMatched(attackLayer, collision.gameObject.layer))
            // 근접 무기가 공격중이고, 적이 충돌 할 때 데미지 입음
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

    private bool CanAttack()    // 가장 가까운 적이 사정거리 내에 있음 + 공격 쿨타임 지남
    {
        return (Vector2.Distance(transform.position, closestEnemy.position) < weaponSO.range && Time.time - timeLastAttack > weaponSO.attackRate);
    }
}
