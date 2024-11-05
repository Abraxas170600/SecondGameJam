using UnityEngine;

public class FireballBullet : Bullet
{
    [Header("AngleDirection")]
    [SerializeField] protected float angleVariation;
    public override void SpawnBullet()
    {
        base.SpawnBullet();
        bulletRb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }

    protected override void BulletConfig()
    {
        transform.rotation *= ApplyRandomAngle();
    }
    private Quaternion ApplyRandomAngle()
    {
        float randomAngle = Random.Range(-angleVariation, angleVariation);
        Quaternion randomRotation = Quaternion.Euler(0, randomAngle, 0);
        return randomRotation;
    }
}
