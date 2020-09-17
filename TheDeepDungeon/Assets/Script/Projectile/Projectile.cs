using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        public float lifeTime;
        public int damage;
        public LayerMask whatIsSolid;
        public GameObject destroyObject;
        public List<string> tagNames;
        public float leftOverTime;
        public float radius;

        private bool isAttackRuneEntered = false;
        private bool isEnemyHit = false;

        // Start is called before the first frame update
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        void Start()
        {
            Invoke("DestroyProjectile", lifeTime);
        }

        private void Update()
        {
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 newPosition = currentPosition + (Vector2)transform.up * speed * Time.deltaTime;
            var hitInfos = Physics2D.OverlapCircleAll(transform.position, radius, whatIsSolid);
            foreach (var hitInfo in hitInfos)
            {
                if (hitInfo != null)
                {
                    if (tagNames.Contains(hitInfo.tag))
                    {
                        var interact = hitInfo.gameObject.GetComponent<IProjectileInteract>();
                        interact.Interact(this);
                    }
                }
            }
            transform.position = newPosition;
        }

        public void DestroyProjectile()
        {
            if (destroyObject != null)
            {
                GameObject leftOver = Instantiate(destroyObject, transform.position, Quaternion.identity);
                Destroy(leftOver, leftOverTime);
            }
            Destroy(gameObject);
        }

        public void SetAttackRuneEntered(bool entered)
        {
            isAttackRuneEntered = entered;
        }

        public bool GetAttackedRuneEntered()
        {
            return isAttackRuneEntered;
        }

        public void SetIsEnemyHit(bool hit)
        {
            isEnemyHit = hit;
        }

        public bool GetIsEnemyHit()
        {
            return isEnemyHit;
        }
    }
}
