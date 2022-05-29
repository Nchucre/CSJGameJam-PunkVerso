using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Compra : MonoBehaviour
{
    public int valorButton;
    public TMP_Text valorTexto;
    public GameObject buttonCompra;
    public GameObject caixaDialogo;
    public TMP_Text textoDialogo;
    public TMP_Text textoMoedas;
    //public Dialogo dialogoScript;
    private void Start()
    {
        
        valorButton = Controlador.instance.valorCompraNovo;
        valorTexto.text = valorButton.ToString() + "  DADOS";
    }

    private void Update()
    {
        textoMoedas.text = "DADOS: " + Controlador.instance.moedas;
    }
    public void ClicaCompra()
    {
         if (Controlador.instance.moedas >= valorButton)
         {
             Comprando();
         }
         else
         {
            caixaDialogo.SetActive(true);
            textoDialogo.text = "Voc� n�o possui dados suficientes";
            StartCoroutine("ApagaDialogo");
            //Debug.Log("N�o possui dados suficientes");
        }
    }

    public void Comprando()
    {
         int valorRandom = Random.Range(0, 10);
         if(Controlador.instance.listaComprados[valorRandom] == 1)
         {//nessa testagem vemos que ele ja possui ent�o chamamos de novo pra tirar um novo numero
            Debug.Log(valorRandom);
            Comprando();
         }
        else
        {
            //COMPRANDO
            Controlador.instance.listaComprados[valorRandom] = 1;
            Controlador.instance.ultimoAtivoIndex = valorRandom;
            Controlador.instance.moedas -= valorButton;
            valorButton += 100;
            Controlador.instance.valorCompraNovo = valorButton;
            valorTexto.text = valorButton.ToString() + "  DADOS";

            //ATIVANDO O DIALOGO DE QUE FOI CONCLUIDA A COMPRA
            caixaDialogo.SetActive(true);
            textoDialogo.text = "Voc� Ganhou " + Controlador.instance.listapersonagens[valorRandom].gameObject.name;
            StartCoroutine("ApagaDialogo");

            //TESTANDO SE JA N�O TEM TODOS E CANCELANDO A COMPRA
            if (valorButton == 1000)
            {
                buttonCompra.SetActive(false);
                valorTexto.text = "Voc� possui todos os punks, Parab�ns!";
            }
        }
        //Debug.Log(valorRandom);
        //Debug.Log(valorButton);
    }

    IEnumerator ApagaDialogo()
    {
        yield return new WaitForSeconds(2f);
        caixaDialogo.SetActive(false);
    }
}
