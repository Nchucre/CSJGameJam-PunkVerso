using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator anim;
    public int valorRandom;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        SegundaAnima();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SegundaAnima()
    {
        valorRandom = Random.Range(0, 4);
        if(valorRandom == 2)
        {
            anim.SetBool("Anima2", true);
            //anim.SetBool("Anima2", false);
            StartCoroutine("TempoAnima");
        }
        else
        {
            StartCoroutine("TempoAnima");
        }
    }

    IEnumerator TempoAnima()
    {
        yield return new WaitForSeconds(3f);

        anim.SetBool("Anima2", false);
        SegundaAnima();
    }
}
