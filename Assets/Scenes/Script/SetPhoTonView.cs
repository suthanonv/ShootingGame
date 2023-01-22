using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SetPhoTonView : MonoBehaviour
{
    public PhotonView view;


    public void SetView(PhotonView View)
    {
        view = View;
    }
}
