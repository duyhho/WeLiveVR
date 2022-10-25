using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocarController : MonoBehaviour
{
    public GameObject model;
    public Material[] Colors;
    public AudioSource errorTone;

    // Start is called before the first frame update
    void Start()
    {
        if (model) {
            model.GetComponent<MeshRenderer>().material = Colors[0];
        }
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
        if (index == 1) {
            if (errorTone) {
                errorTone.Play();
            }
        }
        if (Colors[index] && model) {
            model.GetComponent<MeshRenderer>().material = Colors[index];
            Invoke("ResetColor", 3);
            
        }
        else {
            if (model)
                model.GetComponent<MeshRenderer>().material = Colors[0];
        }
    }
}
