using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Pickups;

namespace Game.Enemies
{
    public class EnemyDrop : MonoBehaviour
    {
        public EnemyConfig config;
        public Coin coin;
        public GameObject health;
        public Transform coinDropLocation;

        public void DropPickup()
        {
            bool coinDrop = Random.Range(0f, 100f) <= config.coinDropChance;
            int coinDropAmount = Random.Range(config.coinMinDropAmount, config.coinMaxDropAmount + 1);
            if(coinDrop)
            {
                Coin coinObject = Instantiate(coin, coinDropLocation.position, Quaternion.identity);
                coinObject.SetCoinAmount(coinDropAmount);
            }
        }
    } 
}
