using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxHealth;
    public float damageMultiplier = 1f;
    public float attackSpeed = 1f;
    public float defense = 0f;

    private void Start()
    {
        CharacterManager.Instance.Player.stats = this;
    }
}