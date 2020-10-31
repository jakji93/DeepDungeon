using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Stats;

namespace Game.Enemies
{
    [CreateAssetMenu(menuName = "Configuration/Enemy Config")]
    public class EnemyConfig : BaseConfig
    {
        public int coinMinDropAmount;
        public int coinMaxDropAmount;
        [Range(0f, 100f)]
        public float coinDropChance;
    } 
}
