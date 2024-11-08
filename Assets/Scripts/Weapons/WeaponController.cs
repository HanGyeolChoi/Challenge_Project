using System.Linq;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponSO;
    [SerializeField] private LayerMask attackLayer;
    private float timeLastAttack = -30f;
    private Collider2D[] colliders;
    private Transform closestEnemy;


    private void Update()
    {
        //TODO : 만약 적이 사정거리 내로 들어오면 공격
        colliders = Physics2D.OverlapCircleAll(transform.position, weaponSO.range, attackLayer);        // 사거리 내 적 유무 체크
        if (colliders.Length <= 0)
        {
            return;
        }
        else
        {
            if (Time.time - timeLastAttack > weaponSO.attackRate)
            {
                closestEnemy = FindClosestEnemy();
                Attack();
            }
        }
    }

    private Transform FindClosestEnemy()    // 가장 가까운 적 Transform 반환
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

        return col.transform;
    }
    private void Attack()
    {
        timeLastAttack = Time.time;
        //TODO : 공격 애니메이션 재생, 원거리 무기는 투사체 발사
    }


    public void Attack(Vector2 aim)
    {
        if (Time.time - timeLastAttack > weaponSO.attackRate)
        {
            timeLastAttack = Time.time;
            //TODO : 에임쪽으로 공격하는 기능 구현
        }
    }
}