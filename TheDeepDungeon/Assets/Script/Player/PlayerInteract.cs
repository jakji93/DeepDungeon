using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Projectiles;

namespace Game.Players
{
    public class PlayerInteract : MonoBehaviour, IProjectileInteract
    {
        public Health health;

        public void Interact(Projectile projectile)
        {
            if (health != null) health.DealDamage(projectile.damage);
            projectile.DestroyProjectile();
        }

    } 
}
