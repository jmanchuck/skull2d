using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

enum TurnPhase
{
    CARD_PLACEMENT,
    BIDDING,
    SELECT,
}

public class GameState : MonoBehaviour
{

    private Dictionary<int, Player> playerList;
    private int playerTurn;
    private HashSet<int> livePlayers;
    private PhotonView photonView;

    // Start is called before the first frame update
    void Awake()
    {
        photonView = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {

    }


}
