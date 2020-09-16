using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Enemies;

public class Health : MonoBehaviour
{
    public EnemyConfig enemyConfig;
    public Animator animator;
    public HealthBarDisplay healthDisplay;

    private int currentHealth;
    private int maxHealth;
    private bool isAlreadyDead = false;

    private void Start()
    {
        currentHealth = enemyConfig.baseMaxHealth;
        maxHealth = enemyConfig.baseMaxHealth;
        if (healthDisplay != null) healthDisplay.SetHealth(currentHealth, maxHealth);
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        if(currentHealth == 0 && !isAlreadyDead)
        {
            Death();
        }
        if(healthDisplay != null) healthDisplay.SetHealth(currentHealth, maxHealth);
    }

    private void Death()
    {
        //TODO
        if(animator != null) animator.SetTrigger("death");
        isAlreadyDead = true;
        Destroy(gameObject);
    }

    public bool GetAlreadyDead()
    {
        return isAlreadyDead;
    }

    public void RegenerateHealth(int health)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + health);
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth;
    }

    public void IncreaseMaxHealth(int health)
    {
        maxHealth += health;
    }
}
