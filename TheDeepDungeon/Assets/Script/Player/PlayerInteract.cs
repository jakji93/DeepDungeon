using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Projectiles;
using Game.Melees;

namespace Game.Players
{
    public class PlayerInteract : MonoBehaviour, IProjectileInteract, IMeleeInteract
    {
        public PlayerHealth health;

        public void Interact(Projectile projectile)
        {
            if (health != null) health.DealDamage(projectile.damage);
            projectile.DestroyProjectile();
        }

        public void Interact(int damage)
        {
            if (health != null) health.DealDamage(damage);
        }
    } 
}
