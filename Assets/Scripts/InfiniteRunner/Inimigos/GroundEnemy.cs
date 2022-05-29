using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : DadosInimigo
{
    private Rigidbody2D inimigoRb;
    private int velocidade;
    public Transform finalPoint;
    //public GameObject explosao;
    // Start is called before the first frame update
    void Start()
    {
        inimigoRb = this.GetComponent<Rigidbody2D>();
        velocidade = 5;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D infoSolo = Physics2D.Raycast(finalPoint.position, Vector2.down, 2f, LayerMask.GetMask("Solo"));
        if (infoSolo.collider == false)
        {
            velocidade *= -1;
            this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void FixedUpdate()
    {
        inimigoRb.velocity = new Vector2(velocidade, inimigoRb.velocity.y);
    }
}
