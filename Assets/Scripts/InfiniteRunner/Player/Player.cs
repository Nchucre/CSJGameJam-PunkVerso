using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public Animator anim;
    public float speed, alturaPulo;
    public int vida;


    private bool pulou, atacando;
    public GameObject balaPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && pulou == false)
        {
            playerRb.AddForce(new Vector2(0, alturaPulo), ForceMode2D.Impulse);
            pulou = true;
        }

        if(Input.GetMouseButton(0))
        {
            if (atacando == false)
            {
                anim.SetBool("Atk", true);
                Instantiate(balaPrefab, firePoint.position, firePoint.rotation);
                atacando = true;
                StartCoroutine("TempoAtk");
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Atk", false);
            //atacando = false;
        }

        
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(speed, playerRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Solo"))
        {
            pulou = false;
        }

        if(collision.collider.CompareTag("Inimigo"))
        {
            vida -= 1;
            RunnerControler.runnerInstance.textoVida.text = "Vida: " + vida.ToString();

            if(vida <= 0)
            {
                RunnerControler.runnerInstance.GameOver();
            }
        }

        if(collision.collider.CompareTag("Morte"))
        {
            RunnerControler.runnerInstance.GameOver();
        }
    }

    IEnumerator TempoAtk()
    {
        yield return new WaitForSeconds(0.5f);
        atacando = false;
    }
}
