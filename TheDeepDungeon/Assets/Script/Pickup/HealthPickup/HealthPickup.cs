using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Pickups
{
    public class HealthPickup : Pickup
    {
        private int health;

        public override PickupType GetPickupType()
        {
            return PickupType.Health;
        }

        public override int PickupInteract()
        {
            return health;
        }

        public void SetHealthAmount(int amount)
        {
            health = amount;
        }
    }
}
