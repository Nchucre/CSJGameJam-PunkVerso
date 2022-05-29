using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataform : MonoBehaviour
{
    public List<GameObject> listaPlataformas = new List<GameObject>();
    public float offset;
    private Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < listaPlataformas.Count; i++)
        {
            int valorRandom = Random.Range(0, listaPlataformas.Count - 1);
            Instantiate(listaPlataformas[valorRandom], new Vector2(i * 28, 0), transform.rotation);
            offset += 27;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlataforma()
    {
        int valorRandom = Random.Range(0, 5);
        Instantiate(listaPlataformas[valorRandom], new Vector2(offset, 0), transform.rotation);
        offset += 27;
    }

    /*public void Recycle(GameObject plataforma)
    {
        plataforma.transform.position = new Vector2(offset, 0);
        offset += 25;
    }*/
}
