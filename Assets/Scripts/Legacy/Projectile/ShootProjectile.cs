using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private GameObject projectilePrefab, spawner;
    [SerializeField] private bool fromPlayer;
    [SerializeField] private float shootDelay;
    [SerializeField] private int poolSize;
    [SerializeField] List<GameObject> pooledItems = new List<GameObject>();
    private Transform spawnpoint;
    private void Start()
    {
        spawnpoint = spawner.transform;

        InstancePool(poolSize);
        foreach (var clon in pooledItems)
        {
            //para cada clon dentro de la lista, su estado pasara a inactivo (se apagará) y se volverá hijo del GameObject que contenga este script
            clon.SetActive(false);
        }

        if (!fromPlayer)
        {
            StartCoroutine("ShootCoroutine");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (fromPlayer && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Definimos la posición usando el position del objeto y volviendolo el position de uno del spawnPoint en la escena.
        GetObject().transform.position = spawnpoint.position;
        GetObject().transform.rotation = spawnpoint.rotation;
        //procedemos a activar el GameObject para usarlo como necesitemos.
        GetObject().SetActive(true);   
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDelay);
            Shoot();
        }
    }

    private void InstancePool(int amount)
    {
        //hacemos un ciclo for que se va a ejecutar la cantidad de veces que queremos el clon. En este caso el código dentro
        //va a ejecutarse 5 veces ya que eso definimos en el Start()
        for (int i = 0; i < amount; i++)
        {
            //creamos un GameObject temporal que almacene la instancia (clon) del prefab
            GameObject spawnObj = Instantiate(projectilePrefab, spawnpoint.position, spawnpoint.rotation);
            //añadimos dicho clon a la lista
            pooledItems.Add(spawnObj);
            // spawnObj.transform.SetParent(spawnpoint);    
        }
    }

    public GameObject GetObject()
    {
        //Usamos el ciclo for para recorrer la lista de los clones
        for (int i = 0; i < pooledItems.Count; i++)
        {
            //usamos una condición donde preguntamos si el clon actual NO está activado
            if(!pooledItems[i].activeInHierarchy)
            {
                //si NO está activado, lo va a dar como resultado (lo retorna)
                return pooledItems[i];
            }
        }
        
        //aquí se instancia nuevamente 1 elemento adicional (para no causar errores)
        //y retorna ese nuevo objeto sabiendo que es el último en la lista.
        InstancePool(1);
        return pooledItems.Last<GameObject>();
    }
}
