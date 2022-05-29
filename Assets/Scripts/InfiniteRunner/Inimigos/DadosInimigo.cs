using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosInimigo : MonoBehaviour
{
    public int vida;
    public int pontos;

    public virtual void SofreDano()
    {
        vida -= 1;

        if(vida <= 0)
        {
            RunnerControler.runnerInstance.GanhaPontos(pontos);
            Destroy(this.gameObject);
        }
    }


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SofreDano();
        }
    }

}
