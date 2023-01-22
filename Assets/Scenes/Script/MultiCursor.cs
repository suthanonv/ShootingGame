using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon;
public class MultiCursor : MonoBehaviour
{

    public PhotonView view;

    Vector2 targetPos;

    Animator anim;

    public Camera cam;


    private void Start()
    {

        anim = this.GetComponent<Animator>();
    

    }

    void Update()
    {

        if (view.IsMine)
        {
            targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(targetPos);
            transform.position = targetPos;
            Cursor.visible = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
        


    }


    
}
