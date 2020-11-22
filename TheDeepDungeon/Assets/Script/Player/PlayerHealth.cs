using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Stats;

namespace Game.Players
{
    public class PlayerHealth : BaseHealth
    {
        //temp display
        public HealthBarDisplay healthDisplay;

        private void Start()
        {
            base.Start();
            if (healthDisplay != null) healthDisplay.SetHealth(base.currentHealth, maxHealth);
        }

        public override void Death()
        {
            if (animator != null) animator.SetTrigger("death");
        }

        public override void DealDamage(int damage)
        {
            base.DealDamage(damage);
            if (healthDisplay != null) healthDisplay.SetHealth(currentHealth, maxHealth);
        }

        public override void RegenerateHealth(int health)
        {
            base.RegenerateHealth(health);
            if (healthDisplay != null) healthDisplay.SetHealth(currentHealth, maxHealth);
        }
    } 
}
