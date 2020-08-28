using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    public float attackSpeed = 0.5f;
    public Transform shootingPostion;

    private float timeBtwShots;

    // Update is called once per frame
    void Update()
    {
        FireProjectile();
    }

    private void FireProjectile()
    {
        Vector2 shootingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (timeBtwShots <= 0)
        {
            if (Input.GetAxisRaw("Fire3") == 1f)
            {
                GameObject cubeShots = Instantiate(projectile, shootingPostion.position, Quaternion.identity);
                Vector2 direction = (shootingDirection - (Vector2)cubeShots.transform.position).normalized;
                cubeShots.transform.up = direction;
                timeBtwShots = attackSpeed;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void SetProjectile(GameObject newProjectile)
    {
        projectile = newProjectile;
    }
}
