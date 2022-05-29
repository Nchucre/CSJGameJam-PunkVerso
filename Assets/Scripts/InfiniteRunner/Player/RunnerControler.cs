using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RunnerControler : MonoBehaviour
{
    public int pontos;
    public TMP_Text textoPontos;
    public TMP_Text textoVida;
    public TMP_Text textoInicial;
    public TMP_Text textoRecorde;
    public GameObject setinha;
    private int Recorde;

    private bool morto;
    public static RunnerControler runnerInstance;
    // Start is called before the first frame update
    void Awake()
    {
        runnerInstance = this;
    }

    private void Start()
    {
        Time.timeScale = 0;
        morto = false;
        Recorde = PlayerPrefs.GetInt("Recorde");
        textoRecorde.text = "Recorde: "+ Recorde;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && morto == false)
        {
            Time.timeScale = 1;
            textoInicial.gameObject.SetActive(false);
            setinha.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && morto == true)
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.Space) && morto == true)
        {
            SceneManager.LoadScene(1);
        }

    }

    public void GanhaPontos(int ponto)
    {
        pontos += ponto;
        textoPontos.text = "DADOS: " + pontos;
    }

    public void GameOver()
    {
        int moedas = PlayerPrefs.GetInt("Moedas");
        moedas += pontos;
        PlayerPrefs.SetInt("Moedas", moedas);
        if (pontos > Recorde)
        {
            Recorde = pontos;
            PlayerPrefs.SetInt("Recorde", Recorde);
        }
        morto = true;
        Time.timeScale = 0;
        textoInicial.gameObject.SetActive(true);
        textoInicial.text = "GAME OVER" + "\n\n" + "CLIQUE NO BOTÃO ESQUERDO DO MOUSE PARA REINICIAR" + "\n" + "CLIQUE EM ESPAÇO PARA SAIR";
    }

    public void SaveRuner()
    {

    }
}
