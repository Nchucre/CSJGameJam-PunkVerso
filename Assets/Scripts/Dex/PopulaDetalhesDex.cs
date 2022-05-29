using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//**************************//
/*  SCRIPT RESPONSAVEL POR POPULAR A PAGINA DE DETALHES     */
public class PopulaDetalhesDex : MonoBehaviour
{
    public GameObject panelDex;
    public GameObject paginaDetalhes;
    public Sprite imagemPersonagem;
    public string nome;
    public int indice; //indice dele na lista de personagens
    public string familia;
    public string classe;
    public string texto;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivaDetalhesPunk()
    {
        paginaDetalhes.GetComponent<PaginaDetalhes>().imagemPersonagem.sprite = imagemPersonagem;
        paginaDetalhes.GetComponent<PaginaDetalhes>().nomePersonagem.text = nome;
        paginaDetalhes.GetComponent<PaginaDetalhes>().indice = indice;
        paginaDetalhes.GetComponent<PaginaDetalhes>().familia.text = familia;
        paginaDetalhes.GetComponent<PaginaDetalhes>().classe.text = classe;
        paginaDetalhes.GetComponent<PaginaDetalhes>().textoDetalhes.text = texto;

        panelDex.SetActive(false);
    }
}
