using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject Player;

    [SerializeField] private Player[] PlayerList;
    [SerializeField] private int NumberOfPlayers;
    [SerializeField] private GameObject[] Players;


    private void Start()
    {
        PlayerList = PhotonNetwork.PlayerList;
        NumberOfPlayers = PlayerList.Length;
        Players = new GameObject[NumberOfPlayers];

        float xStart = - ((NumberOfPlayers - 1) * 1.8f) / 2;
        for (int i = 0; i < NumberOfPlayers; i++)
        {
            GameObject newPlayer = Instantiate(Player);
            newPlayer.transform.position = new Vector2(xStart + 1.8f * i, 0f);
            newPlayer.GetComponentInChildren<Text>().text = PlayerList[i].ToString();
            newPlayer.GetComponentInChildren<PlayerController>().SetIsMineBool(PlayerList[i].ToString());
            Players[i] = newPlayer;
        }

        Players[0].GetComponentInChildren<PlayerController>().PlayerTurnStart();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
