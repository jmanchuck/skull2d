using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using System.Linq;

public class StartGameController : MonoBehaviour
{
    public Text LobbyNames;
    public Text LobbyCount;

    public void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Update()
    {
        Player[] players = PhotonNetwork.PlayerList;

        LobbyNames.text = string.Join("\n", players.Select(x => x.NickName).ToArray());
        LobbyCount.text = string.Format("Players: {0}", players.Length.ToString());
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("MainScene");
    }
}
