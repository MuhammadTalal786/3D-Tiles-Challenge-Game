using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Pun;


public class RoomListItems : MonoBehaviour
{
    public Text text;
    public GameObject RoomCurrentPlayers;
    public RoomInfo Info;

    RoomOptions options = new RoomOptions();

    public bool privateRoom;

    public static RoomListItems Instance;

    
    
    string pass;

    private void Awake()
    {

        Instance = this;

    }



    public void Setup(RoomInfo _Info,bool isPrivate)
    {
        Info = _Info;
        text.text = _Info.Name;


        if (isPrivate)
        {
            RoomCurrentPlayers.SetActive(true);
            privateRoom = true;
            pass = (string)_Info.CustomProperties["Key"];
        }
    }


    public void Setup_(RoomInfo _Info)
    {
        Info = _Info;
        text.text = _Info.Name;

    }




    public void OnClick()
    {

        if (!privateRoom)
        {
            MultiplayerLauncher.Instance.FindRoomPanel.SetActive(false);
            MultiplayerLauncher.Instance.JoinRoom(Info);
        }
        else if (privateRoom)
        {
            MultiplayerLauncher.Instance.PasswordPanel.SetActive(true);
        }

        
    }

    
    public void onClickInPAnel()
    {
        Debug.Log(MultiplayerLauncher.Instance.UserInputPasswordForCheck.text.ToString());

        if (string.Equals(MultiplayerLauncher.Instance.UserInputPasswordForCheck.text.ToString(), pass))
        {
            MultiplayerLauncher.Instance.PasswordPanel.SetActive(false);
            MultiplayerLauncher.Instance.FindRoomPanel.SetActive(false);
            MultiplayerLauncher.Instance.JoinRoom(Info);
        }
    }

}
