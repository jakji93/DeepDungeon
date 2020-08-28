using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Projectile
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        public float lifeTime;
        public int damage;
        public LayerMask whatIsSolid;
        public GameObject destroyObject;
        public List<string> tagNames;

        private bool isAttackRuneEntered = false;

        // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyProjectile", lifeTime);
        }

        private void Update()
        {
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 newPosition = currentPosition + (Vector2)transform.up * speed * Time.deltaTime;
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, speed * Time.deltaTime, whatIsSolid);
            if (hitInfo.collider != null)
            {
                if (tagNames.Contains(hitInfo.collider.tag))
                {
                    var interacts = hitInfo.collider.gameObject.GetComponents<IProjectileInteract>();
                    foreach(var interact in interacts)
                    {
                        interact.Interact(this);
                    }
                }
            }
            transform.position = newPosition;
        }

        public void DestroyProjectile()
        {
            GameObject cubeLeftOver = Instantiate(destroyObject, transform.position, Quaternion.identity);
            Destroy(cubeLeftOver, 0.2f);
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
    }
}
