using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Pickups
{
    public class Coin : Pickup
    {
        private int coinAmount;

        public override int PickupInteract()
        {
            return coinAmount;
        }

        public void SetCoinAmount(int amount)
        {
            coinAmount = amount;
        }
    } 
}
