using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Projectiles;
using Game.Melees;
using Game.Pickups;

namespace Game.Players
{
    public class PlayerInteract : MonoBehaviour, IProjectileInteract, IMeleeInteract, IPickupInteract
    {
        public PlayerHealth health;
        public PlayerResource resource;

        public void Interact(Projectile projectile)
        {
            if (health != null) health.DealDamage(projectile.damage);
            projectile.DestroyProjectile();
        }

        public void Interact(int damage)
        {
            if (health != null) health.DealDamage(damage);
        }

        public void Interact(Pickup pickup)
        {
            //not  yet: check for coin or health or orb?
            resource.AddCoin(pickup.PickupInteract());
            pickup.DestroyPickup();
        }
    } 
}
