using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    public static SpawningEnemy instace;
     GameObject Enemy;
    [SerializeField] private List<GameObject> EnemyList = new List<GameObject>();
    List<GameObject> CurrentEnemyList = new List<GameObject>(); 
    public float SpawnRange;
    [SerializeField] private float EnemyNewTypeDelay = 30;
    Transform player;

    [SerializeField] private float TimeBetweenSpawn;
    float CurrentTime;

    [SerializeField] float IncreaseTime = 25f;

    int EnemySpawncount = 1;

    bool EndPhase;

    void Awake()
    {
        instace = this;
    }
    void Start()
    {
        CurrentTime = TimeBetweenSpawn;
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(EnemyPlus());
        AddEnemyType(EnemyList[0]);
        StartCoroutine(AddEnemyType());


    }

    public void End(bool IsEnd)
    {
        if(IsEnd)
        {
            EndPhase = true;
        }
        else
        {
            EndPhase = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!EndPhase)
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
    }

    void RandomSpawningEnemy(GameObject enemy)
    {
        float RanX = RandomBetweenToRange(-SpawnRange, SpawnRange);
        float RanY = RandomBetweenToRange(-SpawnRange, SpawnRange);

        Vector2 Point = new Vector2(Random.Range(-5, 5) + player.transform.position.x + RanX, Random.Range(-5, 5) + player.transform.position.y + RanY);

        Instantiate(enemy, (Vector3)Point, Quaternion.identity);
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
        while(EnemyList.Count > 0)
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


    float RandomBetweenToRange(float num1,float num2)
    {
        int ran = Random.Range(0, 2);

        if(ran == 1)
        {
            return num1;
        }
        else
        {
            return num2;
        }
                
    }
}
