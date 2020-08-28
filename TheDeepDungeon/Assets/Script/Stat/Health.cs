using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public Animator animator;

    private int currentHealth;
    private bool isAlreadyDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        if(currentHealth == 0 && !isAlreadyDead)
        {
            Death();
        }
    }

    private void Death()
    {
        if(animator != null) animator.SetTrigger("death");
        isAlreadyDead = true;
    }

    public bool GetAlreadyDead()
    {
        return isAlreadyDead;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
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
