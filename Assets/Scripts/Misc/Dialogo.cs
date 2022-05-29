using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public GameObject caixaDialogo;
    public Transform personagemParent;
    public TMP_Text dialogoTexto;
    //public string texto;
    public string nomePersonagemAtivo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void AtivaDialogos()
    {
        foreach(Transform t in personagemParent)
        {
            if(t.gameObject.activeSelf)
            {
                nomePersonagemAtivo = t.gameObject.name;
            }
        }
        caixaDialogo.SetActive(true);
        //texto = "Você ganhou " + nomePersonagemAtivo;
        dialogoTexto.text = "Você ganhou " + nomePersonagemAtivo;
        StartCoroutine("ApagaDialogo");
    }

    IEnumerator ApagaDialogo()
    {
        yield return new WaitForSeconds(1.5f);
        caixaDialogo.SetActive(false);
    }
}
