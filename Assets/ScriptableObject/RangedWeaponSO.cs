using UnityEngine;

[CreateAssetMenu(fileName = "Ranged", menuName = "New Ranged")]
public class RangedWeaponSO : WeaponSO
{
    [Header("Projectile")]
    public float spread;
    public int projectileNum;
    public float projectileSpeed;
    public int penetrationNum;
    public GameObject projectilePrefab;
}