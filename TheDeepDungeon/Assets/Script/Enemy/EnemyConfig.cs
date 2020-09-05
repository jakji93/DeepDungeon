using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    [CreateAssetMenu(menuName = "Enemy Config")]
    public class EnemyConfig : ScriptableObject
    {
        public int baseMaxHealth;
        public float baseMoveSpeed;
        public int baseDamange;
    } 
}
