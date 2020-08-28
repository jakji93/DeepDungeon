using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Projectile;

public class ProjectileWall : MonoBehaviour, IProjectileInteract
{
    public void Interact(Projectile projectile)
    {
        projectile.DestroyProjectile();
    }
}
