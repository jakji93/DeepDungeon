using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Projectiles;

namespace Game.Enemies
{
    [CreateAssetMenu(menuName = "Enemy Type/Cultist Mage")]
    public class CultistMage : EnemyType
    {
        public GameObject projectile;

        public override void Attack(int damage, Transform attackPosition)
        {
            GameObject darkOrb = Instantiate(projectile, attackPosition.position, Quaternion.identity);
            Transform playerBody = GameObject.FindWithTag("Player").transform.Find("Body");
            Vector2 direction = ((Vector2)playerBody.position - (Vector2)darkOrb.transform.position).normalized;
            darkOrb.transform.up = direction;
            var projectileScript = darkOrb.GetComponent<Projectile>();
            projectileScript.damage = damage;
        }
    } 
}
