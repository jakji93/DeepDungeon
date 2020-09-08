using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runes
{
    public abstract class PlayerRune : MonoBehaviour, IRune
    {

        public RuneConfig runeConfig;
        public bool PlayerIsInside { get; private set; } = false;
        public GameObject PlayerOnject { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyRune", runeConfig.lifeTime);
            transform.localScale = transform.localScale * runeConfig.size;
            PlayerOnject = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            var playerIn = GetPlayerInside();
            if (playerIn && !PlayerIsInside)
            {
                PlayerIsInside = true;
                WhenPlayerEnters();
            }
            else if (!playerIn && PlayerIsInside)
            {
                PlayerIsInside = false;
                WhenPlayerLeaves();
            }
            else if(playerIn && PlayerIsInside)
            {
                WhenPlayerStay();
            }
        }

        public bool GetPlayerInside()
        {
            var radius = gameObject.GetComponent<CircleCollider2D>().radius;
            radius = radius * runeConfig.size;
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, runeConfig.layerMask);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Player")
                {
                    return true;
                }
            }
            return false;
        }

        public abstract void WhenPlayerEnters();
        public abstract void WhenPlayerStay();
        public abstract void WhenPlayerLeaves();

        public virtual void DestroyRune()
        {
            Destroy(gameObject);
        }

        public int GetCost()
        {
            return runeConfig.cost;
        }

        public bool GetIsBuffRune()
        {
            return runeConfig.IsBuffRune;
        }
    } 
}
