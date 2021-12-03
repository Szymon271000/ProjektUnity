using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPosition;
    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.gameObject.transform.position, spawnPosition);
        if (distance < 200)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        if (!started)
        {
            spawnPosition = new Vector3(0, 0, spawnPosition.z + 60);
            started = true;
        }
        else
        {
            spawnPosition = new Vector3(0, 0, spawnPosition.z + 20);
            //int randomNum = Random.Range(0, 3);

            Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPosition, Quaternion.identity);
        }
        
    }
}
