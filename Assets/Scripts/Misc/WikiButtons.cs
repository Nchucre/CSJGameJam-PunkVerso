using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WikiButtons : MonoBehaviour
{
    public List<string> textos;
    public TMP_Text caixaTexto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscreveTexto(int indice)
    {
        int index = indice;
        caixaTexto.text = textos[indice];
    }
}
