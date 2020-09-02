using Game.Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runes
{
    public class AttackRune : MonoBehaviour, IProjectileInteract, IRune
    {
        public RuneConfig runeConfig;
        public LayerMask layerMask;
        public float damageReductionInRune;

        // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyRune", runeConfig.GetLifeTime());
            transform.localScale = transform.localScale * runeConfig.GetSize();
        }

        public void DestroyRune()
        {
            Destroy(gameObject);
        }

        public int GetCost()
        {
            return runeConfig.GetCost();
        }

        public void Interact(Projectile projectile)
        {
            if (!projectile.GetAttackedRuneEntered())
            {
                Debug.Log("attack rune entered");
                projectile.SetAttackRuneEntered(true);
                GetEnemiesInside(projectile);
            }
        }

        public bool GetIsBuffRune()
        {
            return runeConfig.GetIsBuffRune();
        }

        public void GetEnemiesInside(Projectile projectile)
        {
            var radius = gameObject.GetComponent<CircleCollider2D>().radius;
            radius = radius * runeConfig.size;
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
            foreach(var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Enemy")
                {
                    Debug.Log("enemy in rune");
                    var health = hitCollider.GetComponentInChildren<Health>();
                    health.DealDamage((int)(projectile.damage * damageReductionInRune));
                }
            }
        }
    } 
}
