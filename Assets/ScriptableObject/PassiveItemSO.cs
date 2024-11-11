using UnityEngine;


[CreateAssetMenu(fileName = "Passive", menuName = "New PassiveItem")]
public class PassiveItemSO : ScriptableObject
{
    public Sprite icon;
    public int health;
    public float speed;
    public float damage;
    public float damageMult;
    public float attackSpeed;
    public float defense;
    public float range;
    public int penetration;

    public int price;
}