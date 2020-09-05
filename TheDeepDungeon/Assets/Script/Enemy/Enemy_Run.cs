using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class Enemy_Run : StateMachineBehaviour
    {
        private EnemyController enemyController;
        private float speed;
        private Rigidbody2D rb;
        private Vector3 lastKnownLocation;
        private List<Vector3> lastKnownLocations = new List<Vector3>();

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            enemyController = animator.transform.parent.GetComponent<EnemyController>();
            rb = animator.transform.parent.GetComponent<Rigidbody2D>();
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
                var lastLocation = lastKnownLocations[0];
                if(!enemyController.IsNotInsight(lastKnownLocations[lastKnownLocations.Count - 1]))
                {
                    lastKnownLocation = enemyController.GetPlayerLocationV3();
                }
                else
                {
                    lastKnownLocations.Add(lastKnownLocation);
                }
                if (Vector3.Distance(rb.position, lastLocation) < 1f)
                {
                    lastKnownLocations.RemoveAt(0);
                }
                else
                {
                    var target = new Vector2(lastLocation.x, lastLocation.y);
                    MoveToPosition(target);
                }
            }
            else
            {
                lastKnownLocations.Clear();
                lastKnownLocations.Add(enemyController.GetPlayerLocationV3());
                var target = enemyController.GetPlayerLocation();
                MoveToPosition(target);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{

        //}

        private void MoveToPosition(Vector2 target)
        {
            var newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
    }
}
