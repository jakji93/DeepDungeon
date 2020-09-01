using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runes
{
    [CreateAssetMenu(menuName = "Rune Config")]
    public class RuneConfig : ScriptableObject
    {
        public float lifeTime;
        public float size;
        public int cost;
        public bool IsBuffRune;

        public float GetLifeTime()
        {
            return lifeTime;
        }

        public float GetSize()
        {
            return size;
        }

        public int GetCost()
        {
            return cost;
        }

        public bool GetIsBuffRune()
        {
            return IsBuffRune;
        }
    } 
}
