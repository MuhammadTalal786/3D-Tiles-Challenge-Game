using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonViewController : MonoBehaviour
{

    public GameObject Camera, JoyStick;

    // Start is called before the first frame update
    void Start()
    {
        //if (!GetComponent<PhotonView>().IsMine)
        //{
        //    Camera.SetActive(false);
        //    JoyStick.SetActive(false);
        //}
    }

    
}
