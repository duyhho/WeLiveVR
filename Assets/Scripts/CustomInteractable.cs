using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class CustomInteractable : XRGrabInteractable
{
    // Start is called before the first frame update
    public Transform attachTransformLeft;
    public Transform attachTransformRight;
    public TrocarController trocarController;
    private XRBaseController currentAttachController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void CheckHand() {
        Debug.Log("CHECKING HAND!");
        XRBaseInteractor interactor = selectingInteractor;
        if (interactor) {
            Debug.Log(interactor);
            if (interactor.name.Contains("LeftHand")) {
                        Debug.Log("LEFTTT!");
                        currentAttachController = interactor.gameObject.GetComponent<XRBaseController>();
                        trocarController.currentController = currentAttachController;
                        // Debug.Log(currentAttachController);
                        if (attachTransformLeft) {
                            attachTransform = attachTransformLeft;
                        }
                }
                else if (interactor.name.Contains("RightHand")) {
                    currentAttachController = interactor.gameObject.GetComponent<XRBaseController>();
                    trocarController.currentController = currentAttachController;

                    // Debug.Log(currentAttachController);
                    Debug.Log("Rightttt!");
                    if (attachTransformRight) {
                            attachTransform = attachTransformRight;
                        }
                }
        }
    }
    

    
}
