using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Players
{
    public class PlayerResource : MonoBehaviour
    {
        private int coin = 0;
        public void AddCoin(int amount)
        {
            coin += amount;
        }

        public void UseCoin(int amount)
        {
            coin -= amount;
        }

        public bool CanBuy(int amount)
        {
            return coin >= amount;
        }

        public int GetCoin()
        {
            return coin;
        }
    } 
}
