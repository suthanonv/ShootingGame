using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawning : MonoBehaviour
{
    public static PlanetSpawning instance;

    [SerializeField] List<GameObject> Planet = new List<GameObject>();
    List<Vector3> currentPoint = new List<Vector3>();
    [SerializeField] ChestOpened Chest;
    List<Vector3> ChestLocation = new List<Vector3>();
    Transform Player;
    [SerializeField] private float SpawnRangeBtwPlayer;
    [SerializeField] private float SpawnRangeBtwPlanet;
    [SerializeField] private float SpawnRangeBtwChestToChest;
    [SerializeField] private float SpawnRangeBtwChestToPlanet;
    [SerializeField] private int PlanetCount = 5;
    [SerializeField] private int ChestCount = 25;
    

    [SerializeField] Vector2 RandomRange = new Vector2();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        SpawnPlanet();
        SpawnChast();
    }

    // Update is called once per frame
    void SpawnPlanet()
    {
        int Count = 0;
        while (Count <= PlanetCount)
        {
            Vector3 spawned = new Vector3(0,0,0);
            spawned = RanPoint();
            Instantiate(GetPlanet(), spawned,Quaternion.identity);

            currentPoint.Add(spawned);
            Count++;
        }
    }

    void SpawnChast()
    {
        int Count = 0;
        while (Count <= ChestCount)
        {
            Vector3 spawned = new Vector3(0, 0, 0);
            spawned = RanChestPoint();
         ChestOpened chest = Instantiate(Chest, spawned, Quaternion.identity);
            chest.SetChestVector3(spawned);
            ChestLocation.Add(spawned);
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

        while (Point.x > -SpawnRangeBtwPlayer && Point.x < SpawnRangeBtwPlayer && Point.y < SpawnRangeBtwPlayer && Point.y > -SpawnRangeBtwPlayer && CheckPlanetRange(Point))
        {
             ranX = Random.Range(-RandomRange.x, RandomRange.x);
             ranY = Random.Range(-RandomRange.y, RandomRange.y);
            Point = new Vector3(ranX, ranY, 0);
        }
        return Point;
    }

   Vector3 RanChestPoint()
    {
        Vector3 Point = new Vector3(0, 0, 0);
        float ranX = Random.Range(-RandomRange.x, RandomRange.x);
        float ranY = Random.Range(-RandomRange.y, RandomRange.y);
        Point = new Vector3(ranX, ranY, 0);

        while (CheckChestRange(Point) && CheckChestToPlayer(Point) && CheckChestToPlanet(Point))
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

    bool CheckChestRange(Vector3 point)
    {
        foreach (var i in ChestLocation)
        {
            if (i.x - SpawnRangeBtwChestToChest < point.x && i.x + SpawnRangeBtwChestToChest > point.x && i.y - SpawnRangeBtwChestToChest < point.y && i.y + SpawnRangeBtwChestToChest > point.y)
            {
                return true;
            }
        }
        return false;
    }

    bool CheckChestToPlayer(Vector3 point)
    {  
            if (Player.transform.position.x - SpawnRangeBtwPlayer < point.x && Player.transform.position.x + SpawnRangeBtwPlayer > point.x && Player.transform.position.y - SpawnRangeBtwPlayer < point.y && Player.transform.position.y + SpawnRangeBtwPlayer > point.y)
            {
                return true;
            }
        return false;
    }
        
    

    bool CheckChestToPlanet(Vector3 point)
    {
        foreach (var i in currentPoint)
        {
            if (i.x - SpawnRangeBtwChestToPlanet  < point.x && i.x + SpawnRangeBtwChestToPlanet > point.x && i.y - SpawnRangeBtwChestToPlanet < point.y && i.y + SpawnRangeBtwChestToPlanet > point.y)
            {
                return true;
            }
        }
        return false;
    }
   
    public void RemoveChest(Vector3 RemovePoint)
    {
        ChestLocation.Remove(RemovePoint);
    }



     public Vector3 NearLestChest(Vector3 Location)
    {
        Vector3 trans = new Vector3(0,0,0);
       float CurrentDis = 9999;
        foreach(Vector3 i in ChestLocation)
        {
            
            if(Vector2.Distance(i, Location) < CurrentDis)
            {
                CurrentDis = Vector2.Distance(i, Location);
                trans = i;
               
            }
        }
        Debug.Log(trans);
        return trans;
    }


}
