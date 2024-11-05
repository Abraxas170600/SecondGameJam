using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Pool")]
    [SerializeField] private int bulletAmount = 10;
    private readonly List<Bullet> bullets = new();

    [Header("Dependences")]
    private Bullet bulletType;
    private void Start()
    {
        CreateBulletPool(bulletAmount);
    }
    private void CreateBulletPool(int bulletAmount)
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            Bullet bullet = Instantiate(bulletType);
            bullet.Initialize(transform);
            bullets.Add(bullet);
        }
    }
    public Bullet GetBullet()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].gameObject.activeInHierarchy)
            {
                return bullets[i];
            }
        }

        CreateBulletPool(1);
        return bullets.Last();
    }
    public void SetBullet(Bullet bullet)
    {
        bulletType = bullet;
    }
}
