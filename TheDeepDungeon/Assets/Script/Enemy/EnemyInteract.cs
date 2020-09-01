using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Projectiles;

public class EnemyInteract : MonoBehaviour, IProjectileInteract
{
    public void Interact(Projectile projectile)
    {
        if (projectile.GetIsEnemyHit()) return;
        projectile.SetIsEnemyHit(true);
        var health = transform.parent.GetComponent<Health>();
        if (health != null) health.DealDamage(projectile.damage);
        projectile.DestroyProjectile();
    }
}
