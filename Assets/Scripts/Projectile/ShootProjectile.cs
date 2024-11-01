using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private GameObject projectileObj, spawner;
    [SerializeField] private bool fromPlayer;
    [SerializeField] private float shootDelay;
    // Update is called once per frame
    void Update()
    {
        if(!fromPlayer){
            InvokeRepeating("shoot", shootDelay, shootDelay);
        }
        else if(
            Input.GetButtonDown("Fire1")){
            shoot();
        }
    }

    void shoot(){
        Instantiate(projectileObj, spawner.transform.position, spawner.transform.rotation);
    }
}
