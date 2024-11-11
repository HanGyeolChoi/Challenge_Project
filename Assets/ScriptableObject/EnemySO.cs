using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class EnemySO : ScriptableObject
{
    [Header("Stats")]
    public int maxHP;
    public float damage;
    public float range;
    public float speed;

    [Header("Drop")]
    public float dropRate;
    public int dropMoney;
}