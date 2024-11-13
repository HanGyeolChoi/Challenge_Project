using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemySO data;
    private Transform playerTransform;
    private Vector2 direction;
    private float distance;

    private void Start()
    {
        playerTransform = CharacterManager.Instance.Player.transform;
    }

    private void FixedUpdate()
    {
        GetEnemyDirection();
        GetDistance();

        UpdateEnemyState();
    }

    private void UpdateEnemyState()
    {
        //if(data.isMelee == true)
        //{
        //  if(distance > minDistance) Move();
        //}
        //
        //else
        //{
        //  if(distance > data.range) Move();
        //  else Attack();
        //}
    }

    private void Move()
    {

    }


    private void GetEnemyDirection()
    {
        direction = (playerTransform.position - transform.position).normalized;
    }
    private void GetDistance()
    {
        distance = Vector2.Distance(transform.position, playerTransform.position);
    }

}