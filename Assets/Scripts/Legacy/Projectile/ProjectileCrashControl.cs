using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCrashControl : MonoBehaviour
{
    [SerializeField] private bool fromPlayer;
    [SerializeField] private float projectileDamage, projectileDestroyTime;
    private float timeToDestroy;

    private void Start()
    {
        timeToDestroy = 0;
    }

    private void Update()
    {
        timeToDestroy += Time.deltaTime;
        if( timeToDestroy > projectileDestroyTime){
            timeToDestroy = 0;
            DestroyProjectile();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.CompareTag("Enemy") && fromPlayer) || (other.gameObject.CompareTag("Player") && !fromPlayer))
        {
            /*  If player shoots and it hit an enemy, the enemy takes damage
                If enemy shoots and it hits the player, the player takes damage */
            //other.gameObject.GetComponent<HealthController>().TakeDamage(projectileDamage);
        }
        gameObject.SetActive(false);
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}
