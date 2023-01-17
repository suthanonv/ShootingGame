using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Walk : MonoBehaviour, StatusChaned
{
    public static Walk Instace;

    [SerializeField] public float walkSpeed;

    public float  CurrentSpeed;
    Vector2 Movement;
    Rigidbody2D rb;
    private float dashCounter;
    private float dashCoolCounter;
    public float dashCooldown;
    public float dashLeagth;

    public KeyCode key = KeyCode.F;

    public UnityEvent DashOn, DashOff;

    Character thisCharacter;

    [SerializeField] OverAllStat CurrentStat;

    float CurrentStatPlus;

    private void Awake()
    {
        Instace = this;
    }
    void Start()
    {
        CurrentSpeed = walkSpeed;
        
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void GetCharacter(Character newChar)
    {
        thisCharacter = newChar;
        walkSpeed = thisCharacter.Stat.Speed[thisCharacter.CurrentLv];
    }

    // Update is called once per frame
    void Update()
    {

        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");

        }
        
    
    
    public void NormleSpeed()
    {
 
        CurrentSpeed = walkSpeed;
    }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + Movement * CurrentSpeed * Time.fixedDeltaTime);
        }

    public void OnStatusChnage()
    {
        Debug.Log("Change");
        if (CurrentStatPlus != CurrentStat.WalkSpeed)
        {
            CurrentStatPlus = CurrentStat.WalkSpeed;
            walkSpeed += walkSpeed * CurrentStat.WalkSpeed;
            CurrentSpeed = walkSpeed;
        }
    }



}