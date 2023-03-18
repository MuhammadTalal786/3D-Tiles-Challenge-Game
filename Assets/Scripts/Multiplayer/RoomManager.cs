using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using UnityEngine.SceneManagement;
using System.IO;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;
    
    
    public int RoomPlayerCount;
    public int JoinedPlayerCount;


    public PhotonView PV;


    public bool startTimer = false;

    public float timeToDisplay=300;
    [SerializeField] double timer = 20;
    [SerializeField] int PlayerCount;

    public bool InternetConnected;


    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        Instance = this;

        
    }

    private void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable || !PhotonNetwork.IsConnected)
        {
            InternetConnected = false;
        }
        else
        {
            InternetConnected = true;
        }
    }


    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnsceneLoaded;
    }



    void OnsceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 1)
        {
            //Vector3 position = PositionSet.instance.PlayerPositions[2].transform.position;

            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            //GameObject.FindGameObjectWithTag("Player").transform.position = position;
        }
    }


    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnsceneLoaded;
    }

    public void UpdatePlayerCountValue(int x)
    {

        PV.RPC("Test", RpcTarget.All, x);

    }

    [PunRPC]
    void Test(int x)
    {
        PlayerCount++;
        print("Player Value Updated ");
    }





    [PunRPC]

    public void ChangePlayerTag(Player playername, string Tag)
    {
        for(int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            if (PhotonNetwork.PlayerList[i] == playername)
            {
                //Swap_Player.Instance.transform.GetChild(0).tag = Tag;
            }
        }

    }

    [PunRPC]
    public void ChangePlayer(Player playerName, int PlayerValue)
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            if (PhotonNetwork.PlayerList[i] == playerName)
            {
                
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == PlayerValue)
                        {
                           // Swap_Player.Instance.player[PlayerValue].SetActive(true);

                        }
                        else
                        {
                          //  Swap_Player.Instance.player[j].SetActive(false);
                        }
                    }
                }
            


        }

    }
}
