using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class CustomInteractable : XRGrabInteractable
{
    // Start is called before the first frame update
    public Transform attachTransformLeft;
    public Transform attachTransformRight;

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
                        if (attachTransformLeft) {
                            attachTransform = attachTransformLeft;
                        }
                }
                else if (interactor.name.Contains("RightHand")) {
                    Debug.Log("Rightttt!");
                    if (attachTransformRight) {
                            attachTransform = attachTransformRight;
                        }
                }
        }
    }
}
