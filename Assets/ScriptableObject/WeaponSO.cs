using UnityEngine;

public enum WeaponType
{
    Melee,
    Ranged
}

[CreateAssetMenu(fileName = "Weapon", menuName = "New Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Info")]
    public string weaponName;
    public string description;
    public WeaponType type;
    public Sprite icon;
    public GameObject prefab;

    [Header("Spec")]
    public float damage;
    public float attackRate;
    public float range;
    public int price;
}
