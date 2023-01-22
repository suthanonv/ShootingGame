using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RadarSkill : MonoBehaviour
{
    public KeyCode key = KeyCode.F;
    [SerializeField] float SkillCD = 10;
    float CurrentCD;
    public Text SkillCDText;
    public GameObject DashAlivableFream;
    public RotateToPoint ArrowPrefab;
    
    
    private void Update()
    {

            if(CurrentCD <= 0)
            {
              if (Input.GetKeyDown(key))
              {
                RotateToPoint Arrow = Instantiate(ArrowPrefab, this.transform.position, Quaternion.identity);
                Arrow.SetPoint(PlanetSpawning.instance.NearLestChest(this.transform.position));
                CurrentCD = SkillCD;
              }
            }
            else
            {
                CurrentCD -= Time.deltaTime;
                DashAlivableFream.SetActive(true);
                SkillCDText.text = CurrentCD.ToString("#.##");
                 if(CurrentCD <= 0)
                {
                    DashAlivableFream.SetActive(false);
                    CurrentCD = 0;
                }
            }
        }
    }


