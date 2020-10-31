using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Pickups
{
    public abstract class Pickup : MonoBehaviour
    {
        public float radius;
        public LayerMask whatIsSolid;
        public List<string> tagNames;
        public GameObject destroyObject;
        public float leftOverTime;

        public abstract int PickupInteract();
        public abstract PickupType GetPickupType();

        public enum PickupType
        {
            Health,
            Coin
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        private void Update()
        {
            var hitInfos = Physics2D.OverlapCircleAll(transform.position, radius, whatIsSolid);
            foreach (var hitInfo in hitInfos)
            {
                if (hitInfo != null)
                {
                    if (tagNames.Contains(hitInfo.tag))
                    {
                        var interact = hitInfo.gameObject.GetComponent<IPickupInteract>();
                        interact.Interact(this);
                    }
                }
            }
        }

        public void DestroyPickup()
        {
            if (destroyObject != null)
            {
                GameObject leftOver = Instantiate(destroyObject, transform.position, Quaternion.identity);
                Destroy(leftOver, leftOverTime);
            }
            Destroy(gameObject);
        }
    } 
}
