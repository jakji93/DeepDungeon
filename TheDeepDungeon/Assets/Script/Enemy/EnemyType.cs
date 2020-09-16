using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public abstract class EnemyType : ScriptableObject
    {
        public abstract void Attack(int damage, Transform attackPosition);
    } 
}
