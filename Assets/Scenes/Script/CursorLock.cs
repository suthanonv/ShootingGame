using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{

    public static CursorLock instance;

    Vector2 targetPos;

    Animator anim;

    bool Paused;

    public Camera cam;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        Cursor.visible = false;
    }

    void Update()
    {
        if (Paused == false)
        {
            targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = targetPos;
        }


    }


    public void MouseLockCheck(bool check)
    {
        if(check)
        {
            Cursor.visible = false;
            Paused = false;
        }
        else
        {
            Cursor.visible = true;
            Paused = true;
        }
    }



    public void MouseChange(bool change)
    {
        if(change == false)
        {
            anim.SetBool("OnClick", false);
        }
        else
        {
            anim.SetBool("OnClick", true);
        }

    }
}
