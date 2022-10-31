using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject LocalXRRigGameObject;
    public GameObject MainAvatarGameObject;
    public GameObject AvatarHeadGameObject;
    public GameObject AvatarBodyGameObject;
    public GameObject SpeakerOut;
    public GameObject[] AvatarModelPrefabs;
    public TextMeshProUGUI PlayerName_Text;
    void Start()
    {
        AvatarInputConverter avatarInputConverter = LocalXRRigGameObject.transform.GetComponent<AvatarInputConverter>();
        Transform AvatarHand_Left = avatarInputConverter.AvatarHand_Left;
        Transform AvatarHand_Right = avatarInputConverter.AvatarHand_Right;

        if (photonView.IsMine)
        {
            //Local player
            LocalXRRigGameObject.SetActive(true);

            //Getting avatar selection to instantiate.
            object avatarSelectionNumber;
            if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(MultiplayerVRConstants.AVATAR_SELECTION_NUMBER, out avatarSelectionNumber))
            {
                Debug.Log("Avatar Selection Number: " + (int)avatarSelectionNumber);
                photonView.RPC("InitializeSelectedAvatarModel", RpcTarget.AllBuffered, (int)avatarSelectionNumber);
            }


            SetLayerRecursively(AvatarHeadGameObject, 6);
            SetLayerRecursively(AvatarBodyGameObject, 7);

            TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();
            if (teleportationAreas.Length > 0)
            {
                Debug.Log("Found " + teleportationAreas.Length + " teleportation area.");
                foreach (var item in teleportationAreas)
                {
                    item.teleportationProvider = LocalXRRigGameObject.GetComponent<TeleportationProvider>();
                }
            }
            MainAvatarGameObject.AddComponent<AudioListener>();

            
            // if (AvatarHand_Left) {
            //     Debug.Log(AvatarHand_Left);
            //     if(AvatarHand_Left.childCount > 0) {
            //         Transform leftHandModel = AvatarHand_Left.transform.GetChild(0);
            //         if (leftHandModel.name.Contains("Hips")) {
            //             if (AvatarHand_Left.transform.GetComponent<XRHandController>())
            //             AvatarHand_Left.transform.GetComponent<XRHandController>().isMine = true;
            //         }
            //         else {

            //             Debug.Log(leftHandModel);
            //             Debug.Log("IS MINE TRUE!");
            //             leftHandModel.GetComponent<XRHandController>().isMine = true;
            //         }
                    
                
            //     }  
            
            // }
            

        }
        else
        {
            //Remote Player
            LocalXRRigGameObject.SetActive(false);
            SetLayerRecursively(AvatarHeadGameObject, 0);
            SetLayerRecursively(AvatarBodyGameObject, 0);
            if (SpeakerOut != null && AvatarHeadGameObject != null) {
            OVRLipSyncContextMorphTarget speakerTarget = SpeakerOut.GetComponent<OVRLipSyncContextMorphTarget>();
            speakerTarget.skinnedMeshRenderer = AvatarHeadGameObject.GetComponentInChildren<SkinnedMeshRenderer>();
            }

            // if (AvatarHand_Left) {
            //     Debug.Log(AvatarHand_Left);
            //     if(AvatarHand_Left.childCount > 0) {
            //         Transform leftHandModel = AvatarHand_Left.transform.GetChild(0);
            //         if (leftHandModel.name.Contains("Hips")) {
            //             if (AvatarHand_Left.transform.GetComponent<XRHandController>())
            //             AvatarHand_Left.transform.GetComponent<XRHandController>().isMine = false;
            //         }
            //         else {

            //             Debug.Log(leftHandModel);
            //             Debug.Log("IS MINE FALSE!");
            //             leftHandModel.GetComponent<XRHandController>().isMine = false;
            //         }
                    
                
            //     }  
            
            // }
        }

        if (PlayerName_Text != null)
        {
            PlayerName_Text.text = photonView.Owner.NickName;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
    [PunRPC]
    //PunRPC will execute for all remote players
    public void InitializeSelectedAvatarModel(int avatarSelectionNumber)
    {
        GameObject selectedAvatarGameobject = Instantiate(AvatarModelPrefabs[avatarSelectionNumber], LocalXRRigGameObject.transform);

        AvatarInputConverter avatarInputConverter = LocalXRRigGameObject.transform.GetComponent<AvatarInputConverter>();
        AvatarHolder avatarHolder = selectedAvatarGameobject.GetComponent<AvatarHolder>();
        SetUpAvatarGameobject(avatarHolder.HeadTransform, avatarInputConverter.AvatarHead);
        SetUpAvatarGameobject(avatarHolder.BodyTransform, avatarInputConverter.AvatarBody);
        SetUpAvatarGameobject(avatarHolder.HandLeftTransform, avatarInputConverter.AvatarHand_Left);
        SetUpAvatarGameobject(avatarHolder.HandRightTransform, avatarInputConverter.AvatarHand_Right);
    }

    //Sets avatar a child of the Main Avatar transform

    void SetUpAvatarGameobject(Transform avatarModelTransform, Transform mainAvatarTransform)
    {
        avatarModelTransform.SetParent(mainAvatarTransform);
        avatarModelTransform.localPosition = Vector3.zero;
        avatarModelTransform.localRotation = Quaternion.identity;
    }
}
