using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerListItems : MonoBehaviourPunCallbacks
{
    Player Player;
    public Text text;

    public void Setup(Player _player)
    {
        Player = _player;
        text.text = Player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (Player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }


}
