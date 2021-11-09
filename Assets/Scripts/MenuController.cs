using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class MenuController : MonoBehaviourPunCallbacks
{
    [SerializeField] private string VersionName = "v1.0";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;
    [SerializeField] private Text JoinRoomErrorText;
    [SerializeField] private GameObject StartButton;
    [SerializeField] private byte maxPlayersPerRoom = 4;

    private void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
        JoinRoomErrorText.enabled = false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartButton.SetActive(false);
        ConnectPanel.SetActive(false);
        UsernameMenu.SetActive(true);

    }



    // Keep track of the current process. Since connection is asynchronous and is based on several callbacks from Photon,
    // we need to keep track of this to properly adjust the behavior when we receive call back by Photon.
    // Typically this is used for the OnConnectedToMaster() callback.
    bool isConnecting;


    #region Public Methods

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = VersionName;
    }

    public void JoinRoom()
    {
        if (!PhotonNetwork.JoinRoom(JoinGameInput.text))
        {
            JoinRoomErrorText.enabled = true;
        }
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateGameInput.text);

    }


    #endregion

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        isConnecting = false;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        PhotonNetwork.LoadLevel("LobbyScene");
    }


    #endregion


    public void ChangeUserNameInput()
    {
        if (UsernameInput.text.Length >= 3)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void SetUserName()
    {
        UsernameMenu.SetActive(false);
        ConnectPanel.SetActive(true);
        PhotonNetwork.NickName = UsernameInput.text;
    }

}
