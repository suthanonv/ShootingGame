using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour
{
    public GameObject OpenScreen;
    public GameObject CloseScreen;

   public void OnClick()
    {
        OpenScreen.SetActive(true);
        CloseScreen.SetActive(false);
    }
}
