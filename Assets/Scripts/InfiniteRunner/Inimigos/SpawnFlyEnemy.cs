using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlyEnemy : MonoBehaviour
{
    public List<GameObject> listaInimigos = new List<GameObject>();

    private float timeCount;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        //enemySpawner();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount >= spawnTime)
        {
            enemySpawner();
            timeCount = 0f;
        }
    }

    public void enemySpawner()
    {
        int randomValor = Random.Range(0, 2);
        //int spawnPoint = Random.Range(0, spawnPoints.Count - 1);
        Instantiate(listaInimigos[randomValor], transform.position + new Vector3(0, Random.Range(1f, 4f), 0), transform.rotation);

        spawnTime = Random.Range(1, 4);
    }
}
