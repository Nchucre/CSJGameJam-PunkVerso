using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
            player.position.x + 6f,
            Mathf.Clamp(player.position.y, 1f, 5f),
            this.transform.position.z);
    }
}
