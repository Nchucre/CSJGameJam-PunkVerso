using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public static Controlador instance;
    [Header("Controle de Personagem")]
    public Transform personagensParent;
    public List<Transform> listapersonagens;
    public int ultimoAtivoIndex;

    [Header("Controle de dados")]
    public int valorCompraNovo;
    public int moedas;
    public TMP_Text textoMoedas;
    public TMP_Text textoNome;
    public List<int> listaComprados; //cada posição refere-se a posição dos personagens na lista, 0 se não foi comprado e 1 se foi comprado

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        //instance = this;
        foreach(Transform t in personagensParent)
        {
            listapersonagens.Add(t);
        }
        if (PlayerPrefs.HasKey("Moedas"))
        {
            Load();
        }
        else
        {
            valorCompraNovo = 100;
            moedas = 0;
            int valorRandom = Random.Range(0, 10);
            listaComprados[valorRandom] = 1; // aqui tem que mudar pra receber qual o maluco escolheu na tela inicial ou receber um random
            ultimoAtivoIndex = valorRandom;
        }
    }

    // Update is called once per frame
    void Update()
    {
        textoMoedas.text = "DADOS: " + moedas;

        //ativar sempre o personagem que está com ultimoAtivo
        for(int i = 0; i < listapersonagens.Count; i++)
        {
            if(i == ultimoAtivoIndex)
            {
                listapersonagens[i].gameObject.SetActive(true);
                textoNome.text = listapersonagens[i].gameObject.name;
            }
            else
            {
                listapersonagens[i].gameObject.SetActive(false);
            }
        }

        //pegar o ultimo ativo
        /*foreach (Transform t in personagensParent)
        {

            if (t.gameObject.activeSelf)
            {
                ultimoAtivoIndex = t.GetSiblingIndex();
            }
        }*/
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Moedas", moedas);
        PlayerPrefs.SetInt("ValorCompra", valorCompraNovo);
        //salvando a lista de personagens que ja foram ativados
        for(int i = 0; i < listaComprados.Count; i++)
        {
            PlayerPrefs.SetInt("listaComprados" + i, listaComprados[i]);
        }

        PlayerPrefs.SetInt("UltimoAtivoIndex", ultimoAtivoIndex);
    }

    public void Load()
    {
        moedas = PlayerPrefs.GetInt("Moedas");
        valorCompraNovo = PlayerPrefs.GetInt("ValorCompra");

        //pegando quais foram comprados/ativados
        for(int i = 0; i < listaComprados.Count; i++)
        {
            listaComprados[i] = PlayerPrefs.GetInt("listaComprados" + i);
            if(listaComprados[i] == 1)
            {
                //ativar na Dex

            }
        }

        //reativando o ultimo ativo
        ultimoAtivoIndex = PlayerPrefs.GetInt("UltimoAtivoIndex");
        for(int i = 0; i < listapersonagens.Count; i++)
        {
            if(i == ultimoAtivoIndex)
            {
                listapersonagens[i].gameObject.SetActive(true);
            }
        }
    }

    public void IniciaMiniGame()
    {
        Save();
        SceneManager.LoadScene(2);
    }

    public void OnApplicationQuit()
    {
        Save();
    }

    public void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            Save();
        }
    }

    public void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            Save();
        }
    }
}
