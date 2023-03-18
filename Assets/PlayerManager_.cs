using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager_ : MonoBehaviour
{
    PhotonView PV;
    GameObject Controller;
    private void Awake()
    {
        PV= GetComponent<PhotonView>();
    }

    private void Start()
    {
        
                Controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefas", "PlayerController1"), transform.position, transform.rotation, 0, new object[] { PV.ViewID });
                Controller.gameObject.transform.GetChild(0).transform.position = spawnManager.Instance.spawnPoints[0].transform.position;
            
        }
    

}
