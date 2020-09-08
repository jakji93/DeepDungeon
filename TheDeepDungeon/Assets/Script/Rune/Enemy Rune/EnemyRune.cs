using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runes
{
    public abstract class EnemyRune : MonoBehaviour, IRune
    {
        public RuneConfig runeConfig;

        // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyRune", runeConfig.lifeTime);
            transform.localScale = transform.localScale * runeConfig.size;
        }

        // Update is called once per frame
        void Update()
        {
            GetEnemiesInside();
        }

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

        private void GetEnemiesInside()
        {
            var radius = gameObject.GetComponent<CircleCollider2D>().radius;
            radius = radius * runeConfig.size;
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, runeConfig.layerMask);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Enemy")
                {
                    WhenEnemyEnters();
                }
            }
        }

        public abstract void WhenEnemyEnters();
    } 
}
