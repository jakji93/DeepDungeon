using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class AnimationHelper : MonoBehaviour
    {
        private EnemyController controller;
        private void Start()
        {
            controller = gameObject.GetComponentInParent<EnemyController>();
        }

        public void Attack()
        {
            controller.Attack();
        }
    } 
}
