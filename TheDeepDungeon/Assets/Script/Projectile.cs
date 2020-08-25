using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public LayerMask whatIsSolid;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition = currentPosition + (Vector2)transform.up * speed * Time.deltaTime;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("ProjectileWall"))
            {
                Destroy(gameObject);
            }
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                //do somehthing
            }
        }
        transform.position = newPosition;
    }
}
