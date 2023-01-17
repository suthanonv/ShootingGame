using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterChoose : MonoBehaviour
{
     Character Chare;
    public Image CharaIm;


   public void SetChareE(Character newChar)
    {
        Chare = newChar;
        CharaIm.sprite = Chare.Icon;
    }

    public void CharacterView()
    {
        DesManageMent.instace.SetDes(Chare);
    }
}
