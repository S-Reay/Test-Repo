using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_EnemySpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();
    public float spawnTimer;
    public GameObject minion;
    public GameObject brute;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("SpawnPoint").Length; i++)
        {
            spawnPoints.Add(GameObject.FindGameObjectsWithTag("SpawnPoint")[i]);
        }
        spawnTimer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }
        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = 1.0f;
        }
    }

    void SpawnEnemy()
    {
        int whichPoint = Random.Range(0, spawnPoints.Count);
        int whichEnemy = Random.Range(0, 2);
        if (whichEnemy == 0)
        {
            Instantiate(minion, spawnPoints[whichPoint].transform.position, transform.rotation);
        }
        else if (whichEnemy == 1)
        {
            Instantiate(brute, spawnPoints[whichPoint].transform.position, transform.rotation);
        }

    }
}
