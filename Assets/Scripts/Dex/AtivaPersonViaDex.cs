using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AtivaPersonViaDex : MonoBehaviour
{
    private PaginaDetalhes paginaDetalhes;

    //este script unicamente ativa o personagem atraves do botão da pagina de detalhes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivaPersonagem()
    {
        paginaDetalhes = FindObjectOfType(typeof(PaginaDetalhes)) as PaginaDetalhes;
        Controlador.instance.ultimoAtivoIndex = paginaDetalhes.indice;
    }
}
