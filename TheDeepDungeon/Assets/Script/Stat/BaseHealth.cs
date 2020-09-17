using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Stats
{
    public abstract class BaseHealth : MonoBehaviour
    {
        public BaseConfig config;
        public Animator animator;

        protected int currentHealth;
        protected int maxHealth; 
        protected bool isAlreadyDead = false;

        protected virtual void Start()
        {
            currentHealth = config.baseMaxHealth;
            maxHealth = config.baseMaxHealth;
        }

        public virtual void DealDamage(int damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Max(currentHealth, 0);
            if (currentHealth == 0 && !isAlreadyDead)
            {
                Death();
            }
        }

        public abstract void Death();

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
}
