using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        rigidbody2D.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
