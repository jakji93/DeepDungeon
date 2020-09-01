using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Projectiles;

public class ProjectileWall : MonoBehaviour, IProjectileInteract
{
    public void Interact(Projectile projectile)
    {
        projectile.DestroyProjectile();
    }
}
