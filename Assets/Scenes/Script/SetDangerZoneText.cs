using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetDangerZoneText : MonoBehaviour
{

    public static SetDangerZoneText instacen;
    public Text PlanetName;
    public Text DisstanceText;

    private void Awake()
    {
        instacen = this;
    }

    public void NamePlante(string Name)
    {
        PlanetName.text = Name.ToString();
    }



    public void ShowDistance(float Dis1,float Dis2)
    {
        float distance = Dis1 - Dis2;

    if(distance <= 0)
        {
            DisstanceText.text = "You are in Danger"; 
       }
    else
        {
            DisstanceText.text = "In" + distance.ToString("#.##") + " m";
        }
    }

}
