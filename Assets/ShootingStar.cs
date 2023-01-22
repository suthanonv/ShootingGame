using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    [SerializeField] GameObject Star;
    [SerializeField] float Time;
    [SerializeField] float deletdTime;
    [SerializeField] float StarFoce;
    [SerializeField] float MinY;
    [SerializeField] float MaxY;

    private void Start()
    {
        StartCoroutine(spawnStar());
    }

    IEnumerator spawnStar()
    {
        while(true)
        {
            yield return new WaitForSeconds(Time);
            Vector2 RandomPoint = new Vector2(this.transform.position.x, this.transform.position.y + Random.Range(MinY,MaxY));
       GameObject starfall =      Instantiate(Star, RandomPoint, this.transform.rotation);
            Rigidbody2D rb = starfall.GetComponent<Rigidbody2D>();
            rb.AddForce(this.transform.up * StarFoce, ForceMode2D.Impulse);
            Destroy(starfall, deletdTime);
        }
    }

    
}
