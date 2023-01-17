using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyShooting : MonoBehaviour
{
    public Transform[] Point;
    public GameObject Bullet;
    float CurrentTime;
    [SerializeField] private float ShootTime;
    [SerializeField] private float Forcc;
    [SerializeField] private float Range = 10;
    [SerializeField] private float DashActivateRange = 2;
    [SerializeField] private float DashRange;
    [SerializeField] private float DashSpeed = 2;
    private float Buffrange;
    Transform Player;

    public UnityEvent  stopWalk, resetwalk;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }



    private void Update()
    {
        if(Vector2.Distance(this.transform.position, Player.transform.position) > Range && Vector2.Distance(this.transform.position, Player.transform.position) < Range + DashActivateRange)
        {
                
                this.GetComponent<EnemyWalk>().BUffSpeed(DashSpeed, DashRange);
            
        }

        if (Vector2.Distance(this.transform.position, Player.transform.position) <= Range)
        {
           
            if (CurrentTime <= 0)
            {
                
                for (int i = 0; i < Point.Length;)
                {
                    GameObject projectile = Instantiate(Bullet, Point[i].transform.position, Point[i].transform.rotation);
                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    rb.AddForce(Point[i].up * Forcc, ForceMode2D.Impulse);
                    
                    i++;
                }
                CurrentTime = ShootTime;
                stopWalk.Invoke();
            }
            
            else
            {
                stopWalk.Invoke();
                CurrentTime -= Time.deltaTime;
               
                if(CurrentTime <= 0)
                {
                    resetwalk.Invoke();
                }
            }
        }
        else
        {
            CurrentTime -= Time.deltaTime;
            if(CurrentTime <= 0)
            {
                resetwalk.Invoke();
            }
        }

    }


}
