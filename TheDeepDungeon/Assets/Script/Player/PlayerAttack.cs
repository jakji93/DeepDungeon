using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Projectiles;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    public float timeBetweenShots = 0.5f;
    public Transform shootingPostion;

    private float timeBtwShots;
    private float damageBuff = 1;
    private int baseDamgeBuff = 0;

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
                var projectileScript = cubeShots.GetComponent<Projectile>();
                projectileScript.damage = (int)((projectileScript.damage + baseDamgeBuff) * damageBuff);
                timeBtwShots = timeBetweenShots;
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

    public void IncreaseAttackBuff(float damageIncrease)
    {
        damageBuff += damageIncrease;
    }

    public void DecreaseAttackBuff(float damageDecrease)
    {
        damageBuff = Mathf.Max(1, damageBuff - damageDecrease);
    }
}
