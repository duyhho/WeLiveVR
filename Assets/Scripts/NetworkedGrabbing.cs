using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.XR.Interaction.Toolkit;
public class NetworkedGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    PhotonView m_PhotonView;
    Rigidbody rb;
    bool isBeingHeld = false;
    CustomInteractable XRCustomInteractable;
    void Awake()
    {
        m_PhotonView = GetComponent<PhotonView>();
        XRCustomInteractable = GetComponent<CustomInteractable>();
        if (XRCustomInteractable != null)   {
        XRCustomInteractable.onSelectEntered.AddListener(StartNetworkGrabbingAnimation);

        }
        // XRCustomInteractable.OnSelectExited.AddListener(StopNetworkGrabbingAnimation);


    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            //disable gravity
            rb.isKinematic = true;
            // GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("InHand");

        }
        else
        {
            rb.isKinematic = false;
            // GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Interactable");
        }
    }

    public void OnSelectEntered()
    {
        Debug.Log("Grabbed");
        m_PhotonView.RPC("StartNetworkGrabbing", RpcTarget.AllBuffered);
        if (m_PhotonView.Owner == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("We do not request the ownership. Already mine");
        }
        else
        {
            TransferOwnership();
        }
    }
    public void OnSelectExited()
    {
        Debug.Log("Released");
        m_PhotonView.RPC("StopNetworkGrabbing", RpcTarget.AllBuffered);
    }
    private void TransferOwnership()
    {
        m_PhotonView.RequestOwnership();
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        //check for unique IDs

        if (targetView != m_PhotonView)
        {
            return;
        }
        Debug.Log("Ownership Requested for " + targetView.name + " from " + requestingPlayer.NickName);
        m_PhotonView.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log("Ownership Transferred for " + targetView.name + " from " + previousOwner.NickName);
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {

    }

    [PunRPC]
    public void StartNetworkGrabbing()
    {
        isBeingHeld = true;
        // XRBaseInteractor interactor = selectingInteractor;
        // if (interactor) {
        //     Debug.Log(interactor);
        //     if (interactor.name.Contains("LeftHand")) {
        //                 Debug.Log("Networked Grabbing Left!");
        //                 currentAttachController = interactor.gameObject.GetComponent<XRBaseController>();
        //                 trocarController.currentController = currentAttachController;
        //                 // Debug.Log(currentAttachController);
                       
        //         }
        //         else if (interactor.name.Contains("RightHand")) {
        //             currentAttachController = interactor.gameObject.GetComponent<XRBaseController>();
        //             trocarController.currentController = currentAttachController;

        //             // Debug.Log(currentAttachController);
        //             Debug.Log("Networked Grabbing Right!");
                   
        //         }
        // }
    }
    [PunRPC]
    public void StopNetworkGrabbing()
    {
        isBeingHeld = false;
    }
    void StartNetworkGrabbingAnimation(XRBaseInteractor interactor) {
        Debug.Log("StartNetworkGrabbingAnimation");
        Debug.Log(interactor);
        if (interactor) {
            Debug.Log(interactor);
            Transform GenericVRPlayer = interactor.gameObject.transform.root;

            PhotonView playerPhotonView = GenericVRPlayer.GetComponent<PhotonView>();
            Debug.Log("player name: " + playerPhotonView.name);
            if (interactor.name.Contains("LeftHand")) {
                    Debug.Log("Networked Grabbing Left!");
                    // Debug.Log(currentAttachController);
                    if (playerPhotonView.IsMine) {
                        Transform LeftHandTransform = GenericVRPlayer.GetComponent<MultiplayerVRSynchronization>().leftHandTransform;

                    }
                    else {
                        Transform LeftHandTransform = GenericVRPlayer.GetComponent<MultiplayerVRSynchronization>().leftHandTransform;
                        Debug.Log("LeftHand Transform: ");
                        Debug.Log(LeftHandTransform);
                        Transform XRHandController = LeftHandTransform.GetChild(0);
                        if (XRHandController != null) {
                           XRHandController.GetComponent<XRHandController>().AnimateGrab();
                        }
                    }
                    // playerPhotonView.RPC("StartNetworkGrabbingAnimation", RpcTarget.AllBuffered, "left");
                       
                }
                else if (interactor.name.Contains("RightHand")) {
                
                    // Debug.Log(currentAttachController);
                    Debug.Log("Networked Grabbing Right!");
                    // playerPhotonView.RPC("StartNetworkGrabbingAnimation", RpcTarget.AllBuffered, "right");

                   
                }
        }
    }
}
