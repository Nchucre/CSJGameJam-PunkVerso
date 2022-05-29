using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float larguraBkg;
    private float startPos;
    public float velocidade;
    public float offset;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position.x;
        larguraBkg = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float reposiciona = cam.transform.position.x * (1 - velocidade);
        //aqui eu vou calcular quanto falta pra camera chegar no final da imagem, nesse caso sempre tem essa margem de "1" pra que
        //nunca apareça o final da imagem
        float distancia = cam.transform.position.x * velocidade;
        //aqui eu vou pegando a posição atualizada da camera e mutiplico ela pela velocidade pra que fique mudando

        this.transform.position = new Vector3(startPos + distancia, transform.position.y, transform.position.z);
        //aqui eu vou mudando o transform.x usando a distancia calculada em cima

        if (reposiciona > startPos + larguraBkg)
        {
            //se o valor de resposição for maior que o x0 + a largura (xFinal), ai ele reposiciona
            startPos += (larguraBkg + offset);
        }
    }
}
