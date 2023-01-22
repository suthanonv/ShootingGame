using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInGame : MonoBehaviour
{
    [SerializeField] GameObject Close;
    [SerializeField] GameObject Open;

    public void OnClick()
    {
        Close.SetActive(false);
        Open.SetActive(true);
    }
}
