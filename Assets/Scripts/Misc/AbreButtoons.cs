using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbreButtoons : MonoBehaviour
{
    public List<Transform> buttonsList;
    public Button buttonAbre;
    public Button buttonFecha;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Abre()
    {
        foreach(Transform t in buttonsList)
        {
            t.gameObject.SetActive(true);
        }

        buttonAbre.gameObject.SetActive(false);
        buttonFecha.gameObject.SetActive(true);
    }

    public void Fecha()
    {
        Debug.Log("clicou");
        //start animação de fechar
        for(int i = 0; i < buttonsList.Count; i++)
        {
            Animator anim = buttonsList[i].GetComponent<Animator>();
            anim.SetBool("Fecha", true);
        }
        StartCoroutine("FechouReabre");
    }

    IEnumerator FechouReabre()
    {
        yield return new WaitForSeconds(0.5f);
        buttonAbre.gameObject.SetActive(true);
        buttonFecha.gameObject.SetActive(false);
        foreach (Transform t in buttonsList)
        {
            t.gameObject.SetActive(false);
        }
    }
    
}
