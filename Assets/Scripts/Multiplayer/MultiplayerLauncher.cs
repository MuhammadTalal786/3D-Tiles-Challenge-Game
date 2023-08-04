
/* <<<-----------***************Scripting By Izhar***************----------->>> */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class MultiplayerLauncher : MonoBehaviourPunCallbacks
{
    public InputField CreateRoomNameInput;
    public Text ErrorTextMsg;
    public GameObject CreateJoinRoomPanel;
    public Text RoomName;

    public Transform roomlist;
    public Transform PlayerList;
    public GameObject roomlistPrefab;
    public GameObject PlayerListPrefab;
    public GameObject startGameButton;
    public GameObject DeleteRoomButton;

    public GameObject PublicPrivatePanel;
    public GameObject InputRoomNamePanel;
    public GameObject RoomNamePanel;
    public GameObject FindRoomPanel;

    public Button JoinRoomButton, CreateRoomButton;

    public static MultiplayerLauncher Instance;


    
    public GameObject passwordField;
    public bool isPrivate;
    public bool isPrivateRoom;
    public Text passInput;

    public PhotonView photonView;

    public GameObject PasswordPanel;


    public bool roomType;

    public UnityEngine.UI.Button startGameBtn;


    public Text UserInputPasswordForCheck;


    public GameObject InternetError;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //CreateRoomButton.interactable=false;
        //JoinRoomButton.interactable = false;
        CreateJoinRoomPanel.SetActive(true);
        Debug.Log("Coonecting to Master");
        PhotonNetwork.ConnectUsingSettings();

        photonView = PhotonView.Get(this);
        isPrivate = false;
        
    }


    

    


    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        PhotonNetwork.NickName = "Player " +   UnityEngine.Random.Range(1, 1000).ToString("0000");
        //CreateRoomButton.interactable = true;
        //JoinRoomButton.interactable = true;
        StartCoroutine(checkConection());

    }



    //When User Click on Create Button then panel Will Open for Public and Private room Creation
    public void OnCreateRoomClick()
    {
        CreateJoinRoomPanel.SetActive(false);
        PublicPrivatePanel.SetActive(true);
    }

    //Back to onCreateRoomClickPanel
    public void BackClickFromPublicPrivatePanel()
    {
        CreateJoinRoomPanel.SetActive(true);
        PublicPrivatePanel.SetActive(false);
    }


    public void onPublicClick()
    {
        isPrivate = false;
        passwordField.SetActive(false);
    }

    


    ExitGames.Client.Photon.Hashtable roomProps = new ExitGames.Client.Photon.Hashtable();
    RoomOptions roomOptions = new RoomOptions();

    string[] myRoomProperties = new string[2];


    

    //when user Input Room Name new room Will Create
    public void createRoom()
    {

       

        if (isPrivate)
        {
            if (string.IsNullOrEmpty(CreateRoomNameInput.text) || string.IsNullOrEmpty(passwordField.GetComponent<InputField>().text))
            {
                return;
            }

            
            string roomname = CreateRoomNameInput.text;
            
            roomOptions.MaxPlayers = (byte)2;
            roomOptions.PublishUserId = true;

            roomOptions.CustomRoomPropertiesForLobby= new string[2] { "Key","IsPrivate" };
            string value = passInput.text;
            Debug.LogError(value);
            roomOptions.CustomRoomProperties = new Hashtable(1) { {"Key", value} ,{ "IsPrivate", true } };
            
            PhotonNetwork.CreateRoom(roomname, roomOptions);

            
            
        }
        else
        {
            if (string.IsNullOrEmpty(CreateRoomNameInput.text))
            {
                return;
            }
            string roomname = CreateRoomNameInput.text;
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2;
            roomOptions.PublishUserId = true;
            roomOptions.CustomRoomPropertiesForLobby = new string[1] { "IsPrivate" };

            roomOptions.CustomRoomProperties = new Hashtable(1) { { "IsPrivate", false } };
            PhotonNetwork.CreateRoom(roomname, roomOptions);
            


        }

        
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(PlayerListPrefab, PlayerList).GetComponent<PlayerListItems>().Setup(newPlayer);
    }


    


    public override void OnJoinedRoom()
    {
        PublicPrivatePanel.SetActive(false);
        RoomNamePanel.SetActive(true);
        RoomName.text = PhotonNetwork.CurrentRoom.Name;


        foreach (Transform child in PlayerList)
        {
            
            Destroy(child.gameObject);
        }


        Player[] players = PhotonNetwork.PlayerList;

        for (int i = 0; i < players.Count(); i++)
        {
            
            Instantiate(PlayerListPrefab, PlayerList).GetComponent<PlayerListItems>().Setup(players[i]);
        }

        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        DeleteRoomButton.SetActive(PhotonNetwork.IsMasterClient);


        //if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        //{
        //    startGameBtn.interactable = true;
        //}
        //else
        //{
        //    startGameBtn.interactable = false;
        //}

    }


    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        DeleteRoomButton.SetActive(PhotonNetwork.IsMasterClient);
    }



    public void DeleteRoom()
    {

        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.LeaveRoom();
        }
    }

    public void leaveRoom()
    {

        PhotonNetwork.LeaveRoom();
       
    }



    public void StartGame()
    {
        
        PhotonNetwork.LoadLevel(34);
        
        
    }

    public void forOtherPlayers()
    {
        PhotonNetwork.LoadLevel(1);
    }
   

    public override void OnLeftRoom()
    {

        if (PhotonNetwork.IsMasterClient)
        {
            
        }


        RoomNamePanel.SetActive(false);
        //InputRoomNamePanel.SetActive(false);
        PublicPrivatePanel.SetActive(false);
        CreateJoinRoomPanel.SetActive(true);
        cachedRoomList.Clear();

    }


   IEnumerator checkConection()
    {
        yield return new WaitForSeconds(0.5f);
        if (!RoomManager.Instance.InternetConnected)
        {
            InternetError.SetActive(true);
        }
        else
        {
            InternetError.SetActive(false);
        }
        StartCoroutine(checkConection());
    }


    private static Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {




        foreach (Transform trans in roomlist)
        {
           
                    Destroy(trans.gameObject);
        }


        for (int i = 0; i < roomList.Count; i++)
        {
            RoomInfo info = roomList[i];
            if (info.RemovedFromList)
            {
                cachedRoomList.Remove(info.Name);
            }
            else
            {
                cachedRoomList[info.Name] = info;
            }
        }


        foreach (KeyValuePair<string, RoomInfo> entry in cachedRoomList)
        {

            if (cachedRoomList[entry.Key].CustomProperties["IsPrivate"] != null)
            {

                Instantiate(roomlistPrefab, roomlist).GetComponent<RoomListItems>().Setup(cachedRoomList[entry.Key], (bool)cachedRoomList[entry.Key].CustomProperties["IsPrivate"]);
            }
            else
            {

                Instantiate(roomlistPrefab, roomlist).GetComponent<RoomListItems>().Setup_(cachedRoomList[entry.Key]);
            }
        }


        
           


    }


    


    public void BackToPublicPrivatePanel()
    {
        PublicPrivatePanel.SetActive(true);
        InputRoomNamePanel.SetActive(false);
    }


    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);

        Player[] players = PhotonNetwork.PlayerList;

       
    }






    public void onJoinButtonClick()
    {
        FindRoomPanel.SetActive(true);
        CreateJoinRoomPanel.SetActive(false);
    }

    public void FindRoomToMain()
    {
        FindRoomPanel.SetActive(false);
        CreateJoinRoomPanel.SetActive(true);
    }

    public void onPrivateClick()
    {
        passwordField.SetActive(true);
        isPrivate = true;
    }



    public void onJoinClick()
    {
        RoomListItems.Instance.onClickInPAnel();
    }
    public void BackClick()
    {
        PasswordPanel.SetActive(false);
    }

    public void Back()
	{
        SceneManager.LoadScene("Empty");
	}

   



}
