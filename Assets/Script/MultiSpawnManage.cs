using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSpawnManage : MonoBehaviour
{
    GameObject Enemy;
    [SerializeField] private List<GameObject> EnemyList = new List<GameObject>();
    List<GameObject> CurrentEnemyList = new List<GameObject>();
    public float SpawnRange;
    [SerializeField] private float EnemyNewTypeDelay = 30;
  

    [SerializeField] private float TimeBetweenSpawn;
    float CurrentTime;

    [SerializeField] float IncreaseTime = 25f;

    [SerializeField] int EnemySpawncount = 1;

    GameObject[] Player;
    void Start()
    {
        CurrentTime = TimeBetweenSpawn;
        
        StartCoroutine(EnemyPlus());
        AddEnemyType(EnemyList[0]);
        StartCoroutine(AddEnemyType());


    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime <= 0)
        {
            for (int i = 0; i < EnemySpawncount;)
            {
                Enemy = GetObject();
                RandomSpawningEnemy(Enemy);
                i++;
            }
            CurrentTime = TimeBetweenSpawn;
        }
        else
        {
            CurrentTime -= Time.deltaTime;
        }

    }

    void RandomSpawningEnemy(GameObject enemy)
    {
        float RanX = RandomBetweenToRange(-SpawnRange, SpawnRange);
        float RanY = RandomBetweenToRange(-SpawnRange, SpawnRange);

        Transform player = RandomPlayerTransfomr();

        Vector2 Point = new Vector2(Random.Range(-10, 10) + player.transform.position.x + RanX, Random.Range(-10, 10) + player.transform.position.y + RanY);

        GameObject Enemy =  Instantiate(enemy, (Vector3)Point, Quaternion.identity);
        Enemy.GetComponent<MultiEnemyRotate>().SetEnemyRotate(player);
        Enemy.GetComponent<MultiEnemyWalk>().SetPlayerTransform(player);
        Enemy.GetComponent<MultiEnemyShooting>().SetPlayerTransform(player);
    }


    IEnumerator EnemyPlus()
    {
        while (true)
        {
            yield return new WaitForSeconds(IncreaseTime);
            EnemySpawncount++;
        }
    }


    IEnumerator AddEnemyType()
    {
        while (EnemyList.Count > 0)
        {
            yield return new WaitForSeconds(EnemyNewTypeDelay);
            AddEnemyType(EnemyList[0]);
        }
    }
    void AddEnemyType(GameObject Enemy)
    {
        EnemyList.Remove(Enemy);
        CurrentEnemyList.Add(Enemy);
    }


    GameObject GetObject()
    {
        return CurrentEnemyList[Random.Range(0, CurrentEnemyList.Count)];
    }


    float RandomBetweenToRange(float num1, float num2)
    {
        int ran = Random.Range(0, 2);

        if (ran == 1)
        {
            return num1;
        }
        else
        {
            return num2;
        }

    }

    Transform RandomPlayerTransfomr()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");

        return Player[Random.Range(0, Player.Length)].transform;
    }
}
