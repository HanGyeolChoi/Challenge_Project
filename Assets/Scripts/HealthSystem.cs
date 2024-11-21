using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float curHealth;
    [SerializeField] private float invincibilityTime = 0.5f;
    private float timeSinceLastHit = float.MaxValue;

    public Action onDamageTake;
    public Action onDeath;
    public Action onInvincivilityEnd;

    private void Start()
    {
        curHealth = maxHealth;
    }

    private void Update()
    {
        if (timeSinceLastHit < invincibilityTime)
        {
            timeSinceLastHit += Time.deltaTime;
            if(timeSinceLastHit >= invincibilityTime)
            {
                onInvincivilityEnd?.Invoke();
            }
        }
    }
    public void SetMaxHealth(float health)
    {
        maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        if (curHealth <= 0) return;
        if (timeSinceLastHit < invincibilityTime) return;
        
        timeSinceLastHit = 0f;
        onDamageTake?.Invoke();
        curHealth -= damage;

        if(curHealth <= 0)
        {
            curHealth = 0;
            onDeath?.Invoke();
        }
    }

    public void Heal(float heal)
    {
        curHealth = Mathf.Min(curHealth + heal, maxHealth);
    }
}