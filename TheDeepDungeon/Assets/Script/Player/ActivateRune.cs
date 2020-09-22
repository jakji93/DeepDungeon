using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Runes;

namespace Game.Players
{
    public class ActivateRune : MonoBehaviour
    {
        public GameObject rune1;
        public GameObject rune2;

        public RuneController controller;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(CanActive(rune1)) ActiveRune(rune1);
            }
            if (Input.GetButtonDown("Fire2"))
            {
                if (CanActive(rune2)) ActiveRune(rune2);
            }
        }

        private void ActiveRune(GameObject rune)
        {
            var currentRune = GameObject.FindWithTag(rune.tag);
            if (currentRune != null) currentRune.GetComponent<IRune>().DestroyRune();
            var isBuffRune = rune.GetComponent<IRune>().GetIsBuffRune();
            if (isBuffRune) Instantiate(rune, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
            else Instantiate(rune, transform.position, Quaternion.identity);
        }

        private bool CanActive(GameObject rune)
        {
            var runeCost = rune.GetComponent<IRune>().GetCost();
            return controller.IsConsumeMana(runeCost);
        }
    } 
}
