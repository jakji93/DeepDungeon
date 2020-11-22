using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Pickups;

namespace Game.Enemies
{
    public class EnemyDrop : MonoBehaviour
    {
        public EnemyConfig config;
        [Header("Coin")]
        public Coin coin;
        public Transform coinDropLocation;
        [Header("Health")]
        public HealthPickup health;
        public Transform healthDropLocation;

        public void DropPickup()
        {
            bool coinDrop = Random.Range(0f, 100f) <= config.coinDropChance;
            int coinDropAmount = Random.Range(config.coinMinDropAmount, config.coinMaxDropAmount + 1);
            if(coinDrop)
            {
                Coin coinObject = Instantiate(coin, coinDropLocation.position, Quaternion.identity);
                coinObject.SetCoinAmount(coinDropAmount);
            }
            bool healthDrop = Random.Range(0f, 100f) <= config.healthDropChance;
            int healthDropAmount = Random.Range(config.healthMinDropAmount, config.healthMaxDropAmount + 1);
            if (healthDrop)
            {
                HealthPickup healthObject = Instantiate(health, healthDropLocation.position, Quaternion.identity);
                healthObject.SetHealthAmount(healthDropAmount);
            }
        }
    } 
}
