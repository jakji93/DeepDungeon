using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runes
{
    [CreateAssetMenu(menuName = "Configuration/Rune Config")]
    public class RuneConfig : ScriptableObject
    {
        public float lifeTime;
        public float size;
        public int cost;
        public bool IsBuffRune;
        public LayerMask layerMask;
    } 
}
