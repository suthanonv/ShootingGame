using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class KnockBack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float strength = 16, delay = 0.15f;

    public UnityEvent OnBegin, Ondone;

    Transform Player;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;   
    }
    public void PlayFeedBack(GameObject sender)
    {
        float CurrentStength = strength;
        float CurrentDelay = delay;
        StopAllCoroutines();
        OnBegin?.Invoke();

        if(Vector2.Distance(Player.transform.position,this.transform.position) < 5)
        {
            CurrentStength *= 2;
            CurrentDelay *= 2 ;
        }

        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2d.AddForce(direction * CurrentStength, ForceMode2D.Impulse);
        StartCoroutine(Reset(CurrentDelay));
    }
    private IEnumerator Reset(float delays)
    {
        yield return new WaitForSeconds(delays);
        rb2d.velocity = Vector3.zero;
        Ondone?.Invoke();
    }
}
