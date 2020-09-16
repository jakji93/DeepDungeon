using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Players
{
    [CreateAssetMenu(menuName = "Configuration/Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        public int baseMaxHealth;
        public float baseMoveSpeed;
        public int baseDamange;
        public float baseAttackSpeed;
    } 
}
