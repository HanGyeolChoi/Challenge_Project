﻿

using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public float speed = 5f;
    public float damage = 0f;
    public float damageMult = 1f;
    public float attackSpeed = 1f;
    public int defense = 0;
    public float range = 0f;
    public int penetration = 0;
    public int projectileNum = 0;
    public float projectileSpeed = 1f;

    private void Start()
    {
        CharacterManager.Instance.Player.stats = this;
    }
}