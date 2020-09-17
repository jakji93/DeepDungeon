using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class Enemy_Run : StateMachineBehaviour
    {
        public float wallDistance = 0.3f;
        public float moveDistance = 0.5f;

        private EnemyController enemyController;
        private float speed;
        private Rigidbody2D rb;
        private Vector3 lastKnownLocation;
        private List<Vector3> lastKnownLocations = new List<Vector3>();
        private Collider2D footCollider;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            enemyController = animator.transform.parent.GetComponent<EnemyController>();
            rb = animator.transform.parent.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            footCollider = rb.GetComponent<Collider2D>();
            footCollider.isTrigger = false;
            speed = enemyController.enemyConfig.baseMoveSpeed;
            lastKnownLocation = enemyController.GetPlayerLocationV3();
            lastKnownLocations.Add(enemyController.GetPlayerLocationV3());
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (enemyController.IsNotInSight())
            {
                if (lastKnownLocations.Count == 0) return;
                UpdateLastKnownLocation();
                FollowPlayer();
            }
            else
            {
                ChasePlayer();
                if (enemyController.IsPlayerInAttackRange())
                {
                    rb.bodyType = RigidbodyType2D.Static;
                    footCollider.isTrigger = true;
                    animator.SetTrigger("isAttacking");
                }
            }
        }


        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger("isAttacking");
        }

        private void MoveToPosition(Vector2 target)
        {
            var newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            if(enemyController.IsCloseToWall(rb.transform.right, wallDistance))
            {
                var newTarget = new Vector2(rb.position.x - moveDistance, target.y);
                newPos = Vector2.MoveTowards(rb.position, newTarget, speed * Time.fixedDeltaTime);
            }
            else if (enemyController.IsCloseToWall(-rb.transform.right, wallDistance))
            {
                var newTarget = new Vector2(rb.position.x + moveDistance, target.y);
                newPos = Vector2.MoveTowards(rb.position, newTarget, speed * Time.fixedDeltaTime);
            }
            else if (enemyController.IsCloseToWall(rb.transform.up, wallDistance))
            {
                var newTarget = new Vector2(target.x, rb.position.y - moveDistance);
                newPos = Vector2.MoveTowards(rb.position, newTarget, speed * Time.fixedDeltaTime);
            }
            else if (enemyController.IsCloseToWall(-rb.transform.up, wallDistance))
            {
                var newTarget = new Vector2(target.x, rb.position.y + moveDistance);
                newPos = Vector2.MoveTowards(rb.position, newTarget, speed * Time.fixedDeltaTime);
            }
            enemyController.FlipEnemy(rb.position, target);
            rb.MovePosition(newPos);
        }

        private void UpdateLastKnownLocation()
        {
            if (!enemyController.IsNotInsight(lastKnownLocations[lastKnownLocations.Count - 1]))
            {
                lastKnownLocation = enemyController.GetPlayerLocationV3();
            }
            else
            {
                lastKnownLocations.Add(lastKnownLocation);
            }
        }

        private void FollowPlayer()
        {
            var targetLocation = lastKnownLocations[0];
            if (Vector3.Distance(rb.position, targetLocation) < 0.5f)
            {
                lastKnownLocations.RemoveAt(0);
            }
            else
            {
                var target = new Vector2(targetLocation.x, targetLocation.y);
                MoveToPosition(target);
            }
        }

        private void ChasePlayer()
        {
            lastKnownLocations.Clear();
            lastKnownLocations.Add(enemyController.GetPlayerLocationV3());
            var target = enemyController.GetPlayerLocation();
            MoveToPosition(target);
        }
    }
}
