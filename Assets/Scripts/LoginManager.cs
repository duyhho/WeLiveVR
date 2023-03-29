using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class LoginManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField PlayerName_InputName;
    [SerializeField]
    List<string> names;
    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        string randomName = names[Random.Range(0, names.Count)] + "_" + Random.Range(0, 999).ToString();
        PlayerName_InputName.text = randomName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    public void ConnectAnonymously() {
        PhotonNetwork.NickName = PlayerName_InputName.text;
        PhotonNetwork.ConnectUsingSettings();
    }
    public void ConnectToPhotonServer() {
        if (PlayerName_InputName != null) {
            PhotonNetwork.NickName = PlayerName_InputName.text;
            PhotonNetwork.ConnectUsingSettings();
            // Debug.Log(PhotonNetwork.NickName);
        }
    }
    #region Photon Callback Methods
    public override void OnConnected() {
        Debug.Log("OnConnected is called. The server is available");
        // Debug.Log(PhotonNetwork.NickName);

    }

    public override void OnConnectedToMaster() {
        Debug.Log("Connected to Master Server with player name: " + PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("HomeScene Multiplayer");
    }
    #endregion
}
