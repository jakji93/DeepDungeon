using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runes
{
    public class PowerRune : MonoBehaviour, IRune
    {
        public RuneConfig runeConfig;
        public float damageIncrease;

        private bool playerIsInside = false;

        // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyRune", runeConfig.lifeTime);
            transform.localScale = transform.localScale * runeConfig.size;
        }

        // Update is called once per frame
        void Update()
        {
            GetPlayerInside();
        }

        public int GetCost()
        {
            return runeConfig.cost;
        }

        public bool GetIsBuffRune()
        {
            return runeConfig.IsBuffRune;
        }

        public void DestroyRune()
        {
            DecreasePlayerDamage();
            Destroy(gameObject);
        }

        private void GetPlayerInside()
        {
            var radius = gameObject.GetComponent<CircleCollider2D>().radius;
            radius = radius * runeConfig.size;
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, runeConfig.layerMask);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Player")
                {
                    if (!playerIsInside)
                    {
                        playerIsInside = true;
                        var playerAttack = hitCollider.GetComponent<PlayerAttack>();
                        playerAttack.IncreaseAttackBuff(damageIncrease);
                        return;
                    }
                    else return;
                }
            }
            if (playerIsInside)
            {
                playerIsInside = false;
                DecreasePlayerDamage();
            }
        }

        private void DecreasePlayerDamage()
        {
            var playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                playerObject.GetComponent<PlayerAttack>().DecreaseAttackBuff(damageIncrease);
            }
        }
    } 
}
