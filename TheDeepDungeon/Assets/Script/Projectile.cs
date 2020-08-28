using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public LayerMask whatIsSolid;
    public GameObject destroyObject;

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
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("ProjectileWall"))
            {
                DestroyProjectile();
            }
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                DestroyProjectile();
            }
        }
        transform.position = newPosition;
    }

    private void DestroyProjectile()
    {
        GameObject cubeLeftOver = Instantiate(destroyObject, transform.position, Quaternion.identity);
        Destroy(cubeLeftOver, 0.2f);
        Destroy(gameObject);
    }
}
