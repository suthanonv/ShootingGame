using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Animator anim;
    public GameObject Patical;
    public float TIme;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
            collision.GetComponent<Collider2D>().enabled = false;
            GameObject.FindWithTag("MiniMap").GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(delay());
        }
    }


    IEnumerator delay()
    {
        yield return new WaitForSeconds(TIme);
        anim.SetBool("isEnd", true);
        SetActivePanal.instace.PanelAcitve();
    }
}
