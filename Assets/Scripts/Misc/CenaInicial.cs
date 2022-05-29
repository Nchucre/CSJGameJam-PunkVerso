using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CenaInicial : MonoBehaviour
{
    public TMP_Text dialogoInicial;
    public GameObject panelDialogo;
    public List<string> dialogos;
    public int numerofala;
    public bool firstPlay;
    public GameObject setinha;
    public GameObject jonny;
    public GameObject fade;
    private void Awake()
    {
        /*if (PlayerPrefs.GetInt("FirstPlay") == 1)
        {
            firstPlay = false;
        }
        if (PlayerPrefs.HasKey("Version"))
        {
            string oldVersion = PlayerPrefs.GetString("Version");
            string newVersion = Application.version;
            if(oldVersion.Equals(newVersion))
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                PlayerPrefs.DeleteAll();
                firstPlay = true;
            }
        */
        if(PlayerPrefs.HasKey("FirstPlay"))
        {
            if(PlayerPrefs.GetInt("FirstPlay") == 1)
            {
                firstPlay = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Application.version);
        if (firstPlay == false)
        {
            SceneManager.LoadScene(1);
        }
    }
     
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (numerofala == 0)
            {
                panelDialogo.SetActive(true);
                jonny.SetActive(true);
                setinha.SetActive(false);
                //dialogoInicial.gameObject.SetActive(true);
                dialogoInicial.text = dialogos[numerofala];
                numerofala++;
            }
            else if(numerofala < dialogos.Count)
            {
                dialogoInicial.text = dialogos[numerofala];
                numerofala++;
            }
            else
            {
                Debug.Log("fim dialogo");
                fade.SetActive(true);
                StartCoroutine("CarregaCena");
                PlayerPrefs.SetString("version", Application.version);
            }
        }
    }

    IEnumerator CarregaCena()
    {
        yield return new WaitForSeconds(0.9f);
        PlayerPrefs.SetInt("FirstPlay", 1);
        SceneManager.LoadScene(1);
    }
}
