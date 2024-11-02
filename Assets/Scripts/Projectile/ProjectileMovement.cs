using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Rigidbody projectileRB;
    [SerializeField] private float shootVel, shotIncl, shootDisface; //Shoot speed and inclination

    private void OnEnable() {
        float randomDisface = Random.Range(0, shootDisface);
        projectileRB = GetComponent<Rigidbody>();
        // projectileRB.transform.Rotate(Vector3.right*shotIncl);
        projectileRB.AddRelativeForce((Vector3.forward * shootVel) + Vector3.right* randomDisface, ForceMode.Impulse);  //Simple shot function
        
    }
    private void OnDisable() {
        projectileRB.velocity = Vector3.zero;
        projectileRB.angularVelocity = Vector3.zero;
        projectileRB.Sleep();
    }
}

