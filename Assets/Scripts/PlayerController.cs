using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject SkullCard;
    [SerializeField] public GameObject NormalCard;

    [SerializeField] private List<GameObject> CardsOnHand;
    [SerializeField] private Animator Animator;

    [SerializeField] private bool IsMine;

    public void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void SetIsMineBool(string playerName)
    {
        if (PhotonNetwork.LocalPlayer.ToString() == playerName)
        {
            transform.parent.GetComponentInChildren<Text>().color = Color.red;
        }
    }

    public void RefreshForNewRound()
    {
        CardsOnHand = new List<GameObject>();
        CardsOnHand.Add(Instantiate(SkullCard));
        // SpriteRenderer
        CardsOnHand.Add(Instantiate(NormalCard));
        CardsOnHand.Add(Instantiate(NormalCard));
        CardsOnHand.Add(Instantiate(NormalCard));
    }

    public void PlayerTurnStart()
    {
        if (IsMine)
        {

            // ShowPlayerOptions blahblahblah
        }
        Animator.SetBool("IsThinking", true);
    }

    private void ShowPlayerOptions()
    {
        // show cardsOnHand and betting options
    }

    public void PlayerTurnEnd()
    {
        // animation end
    }
}
