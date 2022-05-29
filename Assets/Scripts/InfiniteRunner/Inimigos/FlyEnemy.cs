using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : DadosInimigo
{
    private Rigidbody2D enemyRb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyRb.velocity = Vector2.left * speed;
    }
}
