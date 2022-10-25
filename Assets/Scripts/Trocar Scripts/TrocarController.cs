using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TrocarController : MonoBehaviour
{
    public GameObject model;
    public Material[] Colors;
    public AudioSource errorTone;
    public XRBaseController currentController;
    // private XRBaseController xr;
    // Start is called before the first frame update
    void Start()
    {
        if (model) {
            model.GetComponent<MeshRenderer>().material = Colors[0];
        }
        // xr = (XRBaseController) GameObject.FindObjectOfType(typeof(XRBaseController));
        // Debug.Log(xr);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetColor() {
        if (model) {
                model.GetComponent<MeshRenderer>().material = Colors[0];
        }
    }
    public void ChangeColor(int index) {
        
        if (Colors[index] && model) {
            model.GetComponent<MeshRenderer>().material = Colors[index];
            Invoke("ResetColor", 3);
            
        }
        else {
            if (model)
                model.GetComponent<MeshRenderer>().material = Colors[0];
        }
    }
    public void PlayErrorTone() {
       
            if (errorTone) {
                errorTone.Play();
            }

    }
    public void SendHaptic() {
        if (currentController)
            currentController.SendHapticImpulse(0.7f, 2f);
    }
}
