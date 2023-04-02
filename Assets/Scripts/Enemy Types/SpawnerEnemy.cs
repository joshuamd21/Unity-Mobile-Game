using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : Enemy
{
    private List<GameObject> Spawns;
    public GameObject spawn;
    private int maxSpawns = 5;

    private float firstSpawn = 0.5f;
    private float spawnRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list 
        Spawns = new List<GameObject>();
        for (int i = 0; i < maxSpawns; i++)
        {
            GameObject obj = (GameObject)Instantiate(spawn);
            obj.SetActive(false);
            Spawns.Add(obj);
            obj.transform.SetParent(this.transform, false); // set as children of Spawn Manager
        }
        InvokeRepeating("SpawnEnemy", firstSpawn, spawnRate);
    }

    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < Spawns.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!Spawns[i].activeInHierarchy)
            {
                return Spawns[i];
            }
        }
        // otherwise, return null   
        return null;
    }

    private void SpawnEnemy()
    {
        GameObject toSpawn = GetPooledObject();
        if (toSpawn is not null)
        {
            toSpawn.transform.position = transform.position;
            toSpawn.SetActive(true);
        }
    }

    // this enemy does not move
    protected override void movement() { }
}
