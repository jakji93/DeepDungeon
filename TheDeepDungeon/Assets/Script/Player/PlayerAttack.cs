﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    public float attackSpeed = 0.5f;

    private float timeBtwShots;

    // Update is called once per frame
    void Update()
    {
        Vector2 shootingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(timeBtwShots <= 0)
        {
            if (Input.GetAxisRaw("Fire1") == 1f)
            {
                GameObject cubeShots = Instantiate(projectile, transform.position, Quaternion.identity);
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