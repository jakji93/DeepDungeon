using Game.Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runes
{
    public class AttackRune : EnemyRune, IProjectileInteract
    {
        public float damageReductionInRune;

        public void Interact(Projectile projectile)
        {
            if (!projectile.GetAttackedRuneEntered())
            {
                projectile.SetAttackRuneEntered(true);
                GetEnemiesInside(projectile);
            }
        }

        private void Update()
        {
            
        }

        public override void WhenEnemyEnters()
        {
            return;
        }

        private void GetEnemiesInside(Projectile projectile)
        {
            var radius = gameObject.GetComponent<CircleCollider2D>().radius;
            radius = radius * runeConfig.size;
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, runeConfig.layerMask);
            foreach(var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Enemy")
                {
                    var health = hitCollider.GetComponentInChildren<Health>();
                    health.DealDamage((int)(projectile.damage * damageReductionInRune));
                }
            }
        }
    } 
}
