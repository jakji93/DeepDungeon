using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        public EnemyConfig enemyConfig;
        public float playerInRange;
        public LayerMask lineOfSight;

        private bool playerDetected = false;
        private Transform player;

        // Start is called before the first frame update
        private void Awake()
        {
            gameObject.GetComponent<Health>().maxHealth = enemyConfig.baseMaxHealth;
        }

        void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            DetectPlayerInRange();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, playerInRange);
        }

        public void DetectPlayerInRange()
        {
            if (playerDetected) return;
            if (Vector2.Distance(transform.position, player.position) < playerInRange) playerDetected = true;
        }

        public bool IsNotInSight()
        {
            return Physics2D.Linecast(transform.position, player.position, lineOfSight);
        }

        public bool IsPlayerDetected()
        {
            return playerDetected;
        }

        public Vector2 GetPlayerLocation()
        {
            return new Vector2(player.position.x, player.position.y);
        }

        public bool IsNotInsight(Vector2 location)
        {
            return Physics2D.Linecast(location, player.position, lineOfSight);
        }

        public Vector3 GetPlayerLocationV3()
        {
            return player.position;
        }
    } 
}
