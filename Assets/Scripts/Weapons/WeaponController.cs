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
        //TODO : ���� ���� �����Ÿ� ���� ������ ����
        colliders = Physics2D.OverlapCircleAll(transform.position, weaponSO.range, attackLayer);        // ��Ÿ� �� �� ���� üũ
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

        return col.transform;
    }
    private void Attack()
    {
        timeLastAttack = Time.time;
        //TODO : ���� �ִϸ��̼� ���, ���Ÿ� ����� ����ü �߻�
    }


    public void Attack(Vector2 aim)
    {
        if (Time.time - timeLastAttack > weaponSO.attackRate)
        {
            timeLastAttack = Time.time;
            //TODO : ���������� �����ϴ� ��� ����
        }
    }
}