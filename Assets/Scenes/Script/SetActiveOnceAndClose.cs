using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnceAndClose : MonoBehaviour
{
    public GameObject Close;
    public GameObject Open;
  public void OnClick()
    {
        Sound.Instace.PLayClick();
        Close.SetActive(false);
        Open.SetActive(true);
    }
}
