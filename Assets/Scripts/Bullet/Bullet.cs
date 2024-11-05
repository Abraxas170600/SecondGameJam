using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Header("Atributtes")]
    [SerializeField] protected float damage;
    [SerializeField] protected float timeLife;
    private float currentTimeLife;

    [Header("Movement")]
    [SerializeField] protected float speed;

    [Header("Dependences")]
    protected Rigidbody bulletRb;
    protected Transform bulletSpawn;
    public virtual void Initialize(Transform bulletSpawn)
    {
        bulletRb = GetComponent<Rigidbody>();

        currentTimeLife = timeLife;
        this.bulletSpawn = bulletSpawn;
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (enabled)
        {
            BulletTimer();
        }
    }
    public virtual void SpawnBullet()
    {
        gameObject.SetActive(true);
        transform.SetPositionAndRotation(bulletSpawn.position, bulletSpawn.rotation);
        BulletConfig();
    }
    protected abstract void BulletConfig();
    private void BulletTimer()
    {
        currentTimeLife -= Time.deltaTime;
        if (currentTimeLife <= 0)
        {
            DesactiveBullet();
        }
    }
    private void DesactiveBullet()
    {
        currentTimeLife = timeLife;
        bulletRb.Sleep();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        DesactiveBullet();
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
