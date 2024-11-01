using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCrashControl : MonoBehaviour
{
    [SerializeField] private bool fromPlayer;
    [SerializeField] private float projectileDamage, projectileDestroyTime;

    private void Start() {
        Invoke("DestroyProjectile", projectileDestroyTime);
    }

    private void OnCollisionEnter(Collision other) {
        if((other.gameObject.CompareTag("Enemy") && fromPlayer) || (other.gameObject.CompareTag("Player") && !fromPlayer)){             
            /*  If player shoots and it hit an enemy, the enemy takes damage
                If enemy shoots and it hits the player, the player takes damage */
            other.gameObject.GetComponent<HealthController>().TakeDamage(projectileDamage);
        }
        Destroy(gameObject);
    }

    private void DestroyProjectile(){
        Destroy(gameObject);
    }
}
