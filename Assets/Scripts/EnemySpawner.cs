using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnRate = 2f;


    private float timeBtwSpawn;
    private GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        timeBtwSpawn = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwSpawn <= 0){
            Transform spawner = spawners[Random.Range(0, spawners.Length)].transform;
            Instantiate(enemyPrefab, spawner.position, spawner.rotation);
            timeBtwSpawn = spawnRate;
        }else{
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
