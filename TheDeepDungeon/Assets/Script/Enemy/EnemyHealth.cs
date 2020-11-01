using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Stats;

namespace Game.Enemies
{
    public class EnemyHealth : BaseHealth
    {
        public HealthBarDisplay healthDisplay;
        public EnemyDrop enemyDrop;

        private void Start()
        {
            base.Start();
            if (healthDisplay != null) healthDisplay.SetHealth(base.currentHealth, maxHealth);
        }

        public override void Death()
        {
            if (animator != null) animator.SetTrigger("death");
            isAlreadyDead = true;
            enemyDrop.DropPickup();
            Destroy(gameObject);
        }

        public override void DealDamage(int damage)
        {
            base.DealDamage(damage);
            if (healthDisplay != null) healthDisplay.SetHealth(currentHealth, maxHealth);
        }
    } 
}
