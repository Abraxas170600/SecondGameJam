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

    private void Awake()
    {
        bulletSpawner.SetBullet(bulletType);
    }

    public void UseWeapon(Animator playerAnim)
    {
        attackSpeedTimer -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            playerAnim.Play("Attack");
            StartCoroutine(ShootBurst());
        }
    }

    public IEnumerator ShootBurst()
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
