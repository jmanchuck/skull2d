using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Ping : MonoBehaviour
{
    private Text PingText;

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsConnected)
        {
            int ping = PhotonNetwork.GetPing();
            PingText = GetComponent<Text>();

            // Sometimes this is null for whatever reason...
            if (PingText == null)
            {
                return;
            }
            PingText.text = string.Format("{0} ms", ping);

            if (ping < 100)
            {
                PingText.color = Color.green;
            }
            else if (ping < 300)
            {
                PingText.color = Color.yellow;
            }
            else
            {
                PingText.color = Color.red;
            }
        }
    }
}
