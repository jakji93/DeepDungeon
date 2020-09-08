using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Projectiles;

public class EnemyInteract : MonoBehaviour, IProjectileInteract
{
    public float knowBackFroce = 2000f;
    public Health health;
    public Rigidbody2D rb;
    public Animator animator;

    public void Interact(Projectile projectile)
    {
        if (projectile.GetIsEnemyHit()) return;
        projectile.SetIsEnemyHit(true);
        if (health != null) health.DealDamage(projectile.damage);
        projectile.DestroyProjectile();
        animator.SetBool("isMoving", true);
        rb.AddForce(projectile.transform.up * knowBackFroce);
    }
}
