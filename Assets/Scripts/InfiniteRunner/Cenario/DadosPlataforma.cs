using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosPlataforma : MonoBehaviour
{
    public Transform finalPoint;
    private Transform playerPos;
    public SpawnPlataform spawnScript;
    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        spawnScript = FindObjectOfType(typeof(SpawnPlataform)) as SpawnPlataform;

    }

    private void Update()
    {
        DestroiPlataforma();
    }
    public void DestroiPlataforma()
    {
        float distance = playerPos.position.x - finalPoint.position.x;

        if(distance > 5)
        {
            spawnScript.MovePlataforma();
            Destroy(this.gameObject);
        }
    }
}
