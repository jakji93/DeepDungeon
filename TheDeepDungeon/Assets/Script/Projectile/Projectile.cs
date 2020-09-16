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

        private bool isAttackRuneEntered = false;
        private bool isEnemyHit = false;

        // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyProjectile", lifeTime);
        }

        private void Update()
        {
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 newPosition = currentPosition + (Vector2)transform.up * speed * Time.deltaTime;
            var hitInfos = Physics2D.RaycastAll(transform.position, transform.up, speed * Time.deltaTime, whatIsSolid);
            foreach (var hitInfo in hitInfos)
            {
                if (hitInfo.collider != null)
                {
                    if (tagNames.Contains(hitInfo.collider.tag))
                    {
                        var interacts = hitInfo.collider.gameObject.GetComponents<IProjectileInteract>();
                        foreach (var interact in interacts)
                        {
                            interact.Interact(this);
                        }
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
