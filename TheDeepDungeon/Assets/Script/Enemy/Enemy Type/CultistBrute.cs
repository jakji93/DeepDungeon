using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Melees;

namespace Game.Enemies
{
    [CreateAssetMenu(menuName = "Enemy Type/Cultist Brute")]
    public class CultistBrute : EnemyType
    {
        public float attackRadius;
        public LayerMask attackMask;

        public override void Attack(int damage, Transform attackPosition)
        {
            var collids = Physics2D.OverlapCircleAll(attackPosition.position, attackRadius, attackMask);
            foreach (var collid in collids)
            {
                if (collid.tag == "Foot")
                {
                    var interact = collid.gameObject.GetComponent<IMeleeInteract>();
                    interact.Interact(damage);
                }
            }
        }
    } 
}
