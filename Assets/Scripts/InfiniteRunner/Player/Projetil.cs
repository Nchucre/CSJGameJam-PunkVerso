using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    private Rigidbody2D balaRb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        balaRb = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 1.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        balaRb.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
