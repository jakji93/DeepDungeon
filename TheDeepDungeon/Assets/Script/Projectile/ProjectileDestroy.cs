using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Projectiles
{
    public class ProjectileDestroy : MonoBehaviour
    {

        public void DestroyProjectile()
        {
            Destroy(gameObject);
        }
    } 
}
