using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiEnemyWalk : MonoBehaviour
{
    Transform Player;
    [SerializeField] private float MoveSpeed;
    float CurrnetSpeed;
    [SerializeField] public float AttackRange;
    Rigidbody2D rb;
    Vector3 dir;
    private Vector2 movement;

    bool CanIncrease = true;

    void Start()
    {
        NormleSpeed();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Player.position - transform.position;
        dir.Normalize();

        movement = dir;
    }


    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) > AttackRange)
        {
            MoveCharacter(movement);
        }

    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * CurrnetSpeed * Time.deltaTime));
    }


    public void BUffSpeed(float speedplus, float Lenght)
    {
        if (CanIncrease)
        {
            CanIncrease = false;
            CurrnetSpeed = speedplus * CurrnetSpeed;
            StartCoroutine(NormleSpeed(Lenght));
        }
    }

    public void NormleSpeed()
    {
        CurrnetSpeed = MoveSpeed;
    }

    public void SetPlayerTransform(Transform newPlayer)
    {
        Player = newPlayer;
    }

        


    IEnumerator NormleSpeed(float Lenght)
    {
        yield return new WaitForSeconds(Lenght);
        NormleSpeed();
        CanIncrease = true;
    }
}
