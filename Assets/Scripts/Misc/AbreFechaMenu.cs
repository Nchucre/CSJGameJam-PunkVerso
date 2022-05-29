using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbreFechaMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbreFecha(GameObject GO)
    {
        if(GO.activeSelf)
        {
            GO.SetActive(false);
        }
        else if(!GO.activeSelf)
        {
            GO.SetActive(true);
        }
    }
}
