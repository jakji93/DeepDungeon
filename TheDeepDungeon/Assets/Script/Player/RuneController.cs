using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Stats;

namespace Game.Players
{
    public class RuneController : MonoBehaviour
    {
        public PlayerConfig config;
        //temp display
        public HealthBarDisplay healthDisplay;

        private int maxMana;
        private int currentMana;
        private float timeBtwRegen;
        private float currentTimeBtwRegen;

        private void Start()
        {
            maxMana = config.baseMana;
            currentMana = maxMana;
            timeBtwRegen = config.baseManaRegenTime;
            if (healthDisplay != null) healthDisplay.SetHealth(currentMana, maxMana);
        }

        private void Update()
        {
            if (currentTimeBtwRegen <= 0)
            {
                currentMana = Mathf.Min(maxMana, currentMana + 1);
                if (healthDisplay != null) healthDisplay.SetHealth(currentMana, maxMana);
                currentTimeBtwRegen = timeBtwRegen;
            }
            else
            {
                currentTimeBtwRegen -= Time.deltaTime;
            }
        }

        public bool IsConsumeMana(int cost)
        {
            if (cost <= currentMana)
            {
                currentMana -= cost;
                if (healthDisplay != null) healthDisplay.SetHealth(currentMana, maxMana);
                return true;
            }
            return false;
        }
    } 
}
