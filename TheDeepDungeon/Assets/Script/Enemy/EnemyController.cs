using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        public EnemyConfig enemyConfig;

        [Header("Movement")]
        public float playerInRange;
        public LayerMask lineOfSight;

        [Header("Attack")]
        public float attackRange;
        public Transform attackPoint;

        [Header("Enemy Type")]
        public EnemyType enemyType;

        private bool playerDetected = false;
        private Transform player;
        private CircleCollider2D collider;

        // Start is called before the first frame update

        void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
            collider = GetComponent<CircleCollider2D>();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }

        // Update is called once per frame
        void Update()
        {
            DetectPlayerInRange();
        }

        public void DetectPlayerInRange()
        {
            if (playerDetected) return;
            if (Vector2.Distance(transform.position, player.position) < playerInRange) playerDetected = true;
        }

        public bool IsPlayerInAttackRange()
        {
            return Vector2.Distance(player.position, transform.position) <= attackRange;
        }

        public bool IsNotInSight()
        {
            return Physics2D.Linecast(transform.position, player.position, lineOfSight);
        }

        public bool IsNotInsight(Vector2 location)
        {
            return Physics2D.Linecast(location, player.position, lineOfSight);
        }

        public bool IsNotInsignt(Vector2 from, Vector2 to)
        {
            return Physics2D.Linecast(from, to, lineOfSight);
        }

        public bool IsPlayerDetected()
        {
            return playerDetected;
        }

        public Vector2 GetPlayerLocation()
        {
            return new Vector2(player.position.x, player.position.y);
        }

        public Vector3 GetPlayerLocationV3()
        {
            return player.position;
        }

        public bool IsCloseToWall(Vector2 direction, float distance)
        {
            var colliderSize = direction * collider.radius;
            return Physics2D.Raycast(transform.position, direction, Mathf.Abs(colliderSize.magnitude) + distance, lineOfSight);
        }

        public void FlipEnemy(Vector2 from, Vector2 target)
        {
            if(target.x < from.x) gameObject.transform.localScale = new Vector2(-1f, 1f);
            else gameObject.transform.localScale = new Vector2(1f, 1f);
        }

        public void Attack()
        {
            enemyType.Attack(enemyConfig.baseDamange, attackPoint);
        }
    } 
}
