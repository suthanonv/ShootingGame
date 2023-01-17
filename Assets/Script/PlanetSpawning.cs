using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawning : MonoBehaviour
{
    public List<GameObject> Planet = new List<GameObject>();
    List<Vector3> currentPoint = new List<Vector3>();
    Transform Player;
    [SerializeField] private float SpawnRangeBtwPlayer;
    [SerializeField] private float SpawnRangeBtwPlanet;
    [SerializeField] private int PlanetCount = 5;
    int Count;

    [SerializeField] Vector2 RandomRange = new Vector2();

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        SpawnPlanet();
    }

    // Update is called once per frame
    void SpawnPlanet()
    {
        while(Count <= PlanetCount)
        {
            Vector3 spawned = new Vector3(0,0,0);
            spawned = RanPoint();
            Instantiate(GetPlanet(), spawned,Quaternion.identity);

            currentPoint.Add(spawned);
            Count++;
        }
    }


    GameObject GetPlanet()
    {
        return Planet[Random.Range(0, Planet.Count)];
    }

    
    Vector3 RanPoint()
    {
        Vector3 Point = new Vector3(0,0,0);
        float ranX = Random.Range(-RandomRange.x, RandomRange.x);
        float ranY = Random.Range(-RandomRange.y, RandomRange.y);
        Point = new Vector3(ranX, ranY, 0);

        while (Point.x > -SpawnRangeBtwPlayer && Point.x < SpawnRangeBtwPlayer && Point.y < SpawnRangeBtwPlayer && Point.y > -SpawnRangeBtwPlayer)
        {
             ranX = Random.Range(-RandomRange.x, RandomRange.x);
             ranY = Random.Range(-RandomRange.y, RandomRange.y);
            Point = new Vector3(ranX, ranY, 0);
        }

        while(CheckPlanetRange(Point))
        {
            ranX = Random.Range(-RandomRange.x, RandomRange.x);
            ranY = Random.Range(-RandomRange.y, RandomRange.y);
            Point = new Vector3(ranX, ranY, 0);
        }

        return Point;
    }
        
    bool CheckPlanetRange(Vector3 point)
    {
        foreach(var i in currentPoint)
        {
            if(i.x - SpawnRangeBtwPlanet < point.x && i.x + SpawnRangeBtwPlanet > point.x && i.y - SpawnRangeBtwPlanet < point.y && i.y + SpawnRangeBtwPlanet > point.y)
            {
                return true;
            }
                    
        }
        return false;
    }
   

}
