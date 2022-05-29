using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGroundEnemy : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySpawner()
    {
        int randomValue = Random.Range(0, 2);
        Instantiate(enemy, spawnPoints[randomValue].transform.position, spawnPoints[randomValue].rotation);
    }
}
