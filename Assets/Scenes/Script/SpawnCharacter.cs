using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    public CharacterList AlivebleChar;

    public Transform CharContent;

    public CharacterChoose item;

    void Start()
    {
        SpawItem();
    }

    void SpawItem()
    {
        foreach(Character i in AlivebleChar.AllCharacter)
        {
            CharacterChoose items = Instantiate(item, CharContent);
            items.SetChareE(i);
        }
                
    }
}
