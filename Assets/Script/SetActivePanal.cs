using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivePanal : MonoBehaviour
{
    public static SetActivePanal instace;

  public  GameObject Panel;
    [SerializeField] private float Timer = 1;


    private void Awake()
    {
        instace = this;
    }
    public void PanelAcitve()
    {
        StartCoroutine(Aciveaed());
    }

    IEnumerator Aciveaed()
    {
        yield return new WaitForSeconds(Timer);
        Panel.SetActive(true);
        CursorLock.instance.MouseLockCheck(false);
        ResultAnimation.instance.RunAnimation();
    }
}
