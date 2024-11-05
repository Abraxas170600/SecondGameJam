using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Dependences")]
    [SerializeField] private Bullet bulletType;
    [SerializeField] private BulletSpawner bulletSpawner;

    [Header("Atributtes")]
    [SerializeField] private float weaponAttackSpeed;
    [SerializeField] private int bulletsPerBurst = 3;
    [SerializeField] private float burstInterval = 0.2f;

    private float attackSpeedTimer;

    private void Start()
    {
        bulletSpawner.SetBullet(bulletType);
    }

    private void Update()
    {
        attackSpeedTimer -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ShootBurst());
        }
    }

    private IEnumerator ShootBurst()
    {
        if (CanShoot())
        {
            for (int i = 0; i < bulletsPerBurst; i++)
            {
                Shoot();

                yield return new WaitForSeconds(burstInterval);
            }
        }
    }

    private void Shoot()
    {
        Bullet currentBullet = bulletSpawner.GetBullet();
        currentBullet.SpawnBullet();
    }

    private bool CanShoot()
    {
        if (attackSpeedTimer <= 0)
        {
            attackSpeedTimer = weaponAttackSpeed;
            return true;
        }
        return false;
    }
}
