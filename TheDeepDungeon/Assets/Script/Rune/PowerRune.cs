using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runes
{
    public class PowerRune : MonoBehaviour, IRune
    {
        public RuneConfig runeConfig;

        // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyRune", runeConfig.GetLifeTime());
            transform.localScale = transform.localScale * runeConfig.GetSize();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public int GetCost()
        {
            return runeConfig.GetCost();
        }

        public bool GetIsBuffRune()
        {
            return runeConfig.GetIsBuffRune();
        }

        public void DestroyRune()
        {
            Destroy(gameObject);
        }
    } 
}
