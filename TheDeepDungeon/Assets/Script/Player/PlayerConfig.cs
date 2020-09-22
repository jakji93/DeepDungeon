using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Stats;

namespace Game.Players
{
    [CreateAssetMenu(menuName = "Configuration/Player Config")]
    public class PlayerConfig : BaseConfig
    {
        public float baseAttackSpeed;
        public int baseMana;
        public float baseManaRegenTime;
    } 
}
