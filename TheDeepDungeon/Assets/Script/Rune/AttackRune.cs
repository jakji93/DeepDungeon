using Game.Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runes
{
    public class AttackRune : MonoBehaviour, IProjectileInteract, IRune
    {
        public RuneConfig runeConfig;
        public float damageReductionInRune;

        // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyRune", runeConfig.lifeTime);
            transform.localScale = transform.localScale * runeConfig.size;
        }

        public void DestroyRune()
        {
            Destroy(gameObject);
        }

        public int GetCost()
        {
            return runeConfig.cost;
        }

        public void Interact(Projectile projectile)
        {
            if (!projectile.GetAttackedRuneEntered())
            {
                projectile.SetAttackRuneEntered(true);
                GetEnemiesInside(projectile);
            }
        }

        public bool GetIsBuffRune()
        {
            return runeConfig.IsBuffRune;
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
