using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Melees;

namespace Game.Enemies
{
    [CreateAssetMenu(menuName = "Enemy Type/Cultist Minion")]
    public class CultistMinion : EnemyType
    {
        public Vector2 attackSize;
        public LayerMask attackMask;

        public override void Attack(int damage, Transform attackPosition)
        {
            var collids = Physics2D.OverlapBoxAll(attackPosition.position, attackSize, 0, attackMask);
            foreach(var collid in collids)
            {
                if(collid.tag == "Body")
                {
                    var interact = collid.gameObject.GetComponent<IMeleeInteract>();
                    interact.Interact(damage);
                }
            }
        }
    }
}
