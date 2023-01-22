using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerWarping : MonoBehaviour
{
    public static PlayerWarping instace;


    Rigidbody2D rb;

    public GameObject WarpGates;

    public Transform Point;

    [SerializeField] float Wait;
    Transform WarpGate;

    bool isMove;
    bool StartRotate;

    Vector2 Movement;

   
    

    private void Awake()
    {
        instace = this;
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(isMove)
        {
            Move(Movement);
        }
    }

    private void Move(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * Walk.Instace.CurrentSpeed * 2 * Time.deltaTime));
    }

    private void Update()
    {
        if (StartRotate)
        {
            Vector3 dif = WarpGate.transform.position - transform.position;
            dif.Normalize();
            float angle = Mathf.Atan2(dif.x, dif.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;

            Movement = dif;
        }
    }


    public void Warping()
    {
        Instantiate(WarpGates, Point.transform.position,Point.transform.rotation);

         WarpGate = GameObject.FindObjectOfType<Gate>().transform;
        StartRotate = true;
        Debug.Log(WarpGate.transform.position);
        StartCoroutine(DelayIng());
    }


    IEnumerator DelayIng()
    {
        yield return new WaitForSeconds(Wait);
        isMove = true;
    }

}
