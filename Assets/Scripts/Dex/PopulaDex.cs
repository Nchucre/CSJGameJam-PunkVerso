using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulaDex : MonoBehaviour
{
    public Transform listaButtonsParent;
    public List<Transform> listaButtons; //botões da Dex
            //public List<int> objetosAtivados; //aqui deve salvar um int com o indice da posição do que foi ativado;
    public List<Color> cores; //cor desativada (0) e ativada (1)
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in listaButtonsParent)
        {
            listaButtons.Add(t);
        }

        foreach (Transform t in listaButtons)
        {
            t.GetComponent<Image>().color = cores[0];
            t.GetComponent<Button>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < listaButtons.Count; i++)
        {
            if(Controlador.instance.listaComprados[i] == 1)
            {
                listaButtons[i].GetComponent<Image>().color = cores[1];
                listaButtons[i].GetComponent<Button>().enabled = true;
            }
        }
    }
}
