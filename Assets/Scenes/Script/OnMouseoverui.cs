using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnMouseoverui : MonoBehaviour
{
    public Text thisText;
    [SerializeField]
    int IncreseSize = 30;
    [SerializeField]
    int NormleSize = 25;
   public void MousePointerEnter()
    {
        playSound.instance.PlayClick();
        thisText.fontSize = IncreseSize;
        Debug.Log("Enter");
    }

    public void MousePOintExiter()
    {
        thisText.fontSize = NormleSize;
        Debug.Log("Exit");
    }
}
