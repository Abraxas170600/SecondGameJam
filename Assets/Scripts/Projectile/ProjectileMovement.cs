using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Rigidbody projectileRB;
    [SerializeField] private float shootVel, shotIncl; //Shoot speed and inclination
    void Start()
    {
        projectileRB = GetComponent<Rigidbody>();
        // projectileRB.transform.Rotate(Vector3.right*shotIncl);
        projectileRB.AddRelativeForce(Vector3.forward * shootVel, ForceMode.Impulse);  //Simple shot function
    }
}

