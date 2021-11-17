using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
//test
struct PlayerStats
{
    public int kills;
    public int wins;
    public int roundsPlayed;

    // Number of times a skull is placed and bid is made
    public int bluffCount;
    // Number of times a bid is made and no skulls are flipped
    public int correctFlipCount;
}

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    private GameObject[] Players = null;
    private GameController Instance = null;

    // Keyed using the actor number Player.ActorNumber

    // Consider mapping to the player controller to disable them?
    private Dictionary<int, Player> playerList;
    private Dictionary<int, PlayerStats> playerStats;
    private int playerTurn;
    private HashSet<int> livePlayers;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Instance = this;
        Player[] playerList = PhotonNetwork.PlayerList;
        int numberOfPlayers = playerList.Length;
        Players = new GameObject[playerList.Length];

        float xStart = -((numberOfPlayers - 1) * 1.8f) / 2;
        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject newPlayer = Instantiate(PlayerPrefab);
            newPlayer.transform.position = new Vector2(xStart + 1.8f * i, 0f);
            newPlayer.GetComponentInChildren<Text>().text = playerList[i].ToString();
            newPlayer.GetComponentInChildren<PlayerController>().SetIsMineBool(playerList[i].ToString());
            Players[i] = newPlayer;
        }

        Players[0].GetComponentInChildren<PlayerController>().PlayerTurnStart();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
