using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class PlayerHealth : MonoBehaviour, StatusChaned
{
    public static PlayerHealth instace; 

    [SerializeField] private int MaxHealth;
    int CurrentHealth;
    [SerializeField] private int MaxShield;
    int CurrentShield;

    public Transform Content;
    public Transform ShieldContent;
    public GameObject Hearth;
    public GameObject Shield;

    public UnityEvent died;
    int count;

    GameObject[] Enemy;
    GameObject[] Bullet;

    [SerializeField] private float ImmuneTime;
    float CurrentImmuneTIme;

    Animator anim;
    bool isDeath = false;

    Character current;

    [SerializeField] OverAllStat stat;


    private void Awake()
    {
        instace = this;
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
        CurrentShield = MaxShield;
        playSound.instance.OnLowHealth(HealthStat.Max);
        SpawnHearth();
        SpawnShield();
        anim = this.GetComponent<Animator>();
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        Bullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
    
    }

 

    public void GetCharacter(Character newChar)
    {
        current = newChar;
        MaxHealth = current.Stat.Health[current.CurrentLv];
        MaxShield = current.Stat.Armor[current.CurrentLv];
        stat.CurrentHealth = MaxHealth;
        stat.CurrentArmor = MaxShield;
    }

    public void TakeDamge()
    {
        if(CurrentShield > 0)
        {
            CurrentShield -= 1;
            stat.CurrentArmor = CurrentShield;
            DestroyingShield();
            if(CurrentShield <= 0)
            {
                CurrentImmuneTIme = ImmuneTime;
            }
        }

        if (CurrentImmuneTIme <= 0 && CurrentShield <=0)
        {
            CurrentHealth -= 1;
            stat.CurrentHealth = CurrentHealth;
            DestroyingHealth();
            CurrentImmuneTIme = ImmuneTime;
        }

        if (CurrentHealth == 1)
        {
            
            playSound.instance.OnLowHealth(HealthStat.low);
        }



        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        Bullet = GameObject.FindGameObjectsWithTag("EnemyBullet");

        if (Enemy != null)
        {
            foreach (GameObject i in Enemy)
            {
                i.GetComponent<KnockBack>().PlayFeedBack(this.gameObject);
            }
        }

        if (Bullet != null)
        {
            foreach (GameObject i in Bullet)
            {
                Destroy(i.gameObject);
            }
        }

    

        if(CurrentHealth <= 0)
        {
            playSound.instance.PausedAlaret(true);
            died.Invoke();
            GameObject.FindObjectOfType<PausedManage>().enabled = false;
            isDeath = true;
            playSound.instance.OnLowHealth(HealthStat.Death);
           
        }
        else
        {
            playSound.instance.PlayHurt();
        }
       
    }


    void SpawnHearth()
    {
        for (int i = 0; i < MaxHealth;) {
            Instantiate(Hearth, Content.transform);
            i++;
        }
    }

    void SpawnShield()
    {
        for(int i =0; i < MaxShield;)
        {
            Instantiate(Shield, ShieldContent.transform);
            i++;
        }
    }
    private void Update()
    {
        if(CurrentImmuneTIme > 0)
        {
            anim.SetBool("isHit", true);
            CurrentImmuneTIme -= Time.deltaTime;
        }
        else
        {
            anim.SetBool("isHit", false);
        }

        if(isDeath)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    void DestroyingHealth()
    {
        foreach(Transform i in Content)
        {
            count++;
        }

        count -= CurrentHealth;

        if(count  > 0)
        {
            foreach (Transform i in Content)
            {
                if(count > 0)
                {
                    Destroy(i.gameObject);
                    count--;              
                }
            }
        }
    }

    void DestroyingShield()
    {

        foreach (Transform i in ShieldContent)
        {
            count++;
        }

        count -= CurrentShield;

        if (count > 0)
        {
            foreach (Transform i in ShieldContent)
            {
                if (count > 0)
                {
                    Destroy(i.gameObject);
                    count--;
                }
            }
        }
    }

    public void OnStatusChnage()
    {
    

        while(CurrentHealth < stat.CurrentHealth)
        {
            CurrentHealth++;
            Instantiate(Hearth, Content.transform);
        }
       
        while(CurrentShield < stat.CurrentArmor)
        {
            CurrentShield++;
            Instantiate(Shield, ShieldContent.transform);
        }
               
    }


}
