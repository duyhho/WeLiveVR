using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class TrocarCollisionDetection : MonoBehaviour
{
    // public GameObject spawnObject = null;
    // Start is called before the first frame update
    // public TextMeshProUGUI pathStatusText;
    // public Text pathStatusText;
    public MeshRenderer renderer;
    public bool playSoundWhenCollided = true;


    void Start()
    {
            // pathStatusText.SetText("You are on the right path!");
            // pathStatusText.color = new Color32( 254 , 9 , 0, 255) ;
        if (renderer == null) {
            renderer = transform.transform.GetComponent<MeshRenderer>();
        }
        if (renderer)
            renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ResetRenderer() {
        if (renderer)
            renderer.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Trocar Tip" ) {
            if (renderer) {
                renderer.enabled = true;
                Transform trocarController = other.gameObject.transform;
                Debug.Log(trocarController);
                trocarController.GetComponent<TrocarController>().ChangeColor(1);
                trocarController.GetComponent<TrocarController>().SendHaptic();

                if (playSoundWhenCollided) {
                    trocarController.GetComponent<TrocarController>().PlayErrorTone();
                }
                Invoke("ResetRenderer", 3);//this will happen after 2 seconds
            }

        }
    }
    // void OnCollisionEnter(Collision collision) {
    //     Debug.Log(collision.gameObject.name);
    //     // if (spawnObject != null) {
    //     //     foreach (ContactPoint contact in collision.contacts) {
    //     //     Debug.Log(contact.point);
    //     //     Debug.DrawRay(contact.point, contact.normal, Color.white);

    //     //     GameObject newSpawnObject = Instantiate(spawnObject, contact.point, Quaternion.identity);
    //     //     newSpawnObject.transform.parent = collision.gameObject.transform;
    //     // }   
    // }
    // void OnCollisionStay(Collision collision) {
    //     Debug.Log(collision.gameObject.name);
    //     // if (collision.gameObject.name == "Guideline") {
    //     //     if (pathStatusText != null) {
    //     //         // pathStatusText.SetText("You are on the right path!");
    //     //         pathStatusText.text = "You are on the right path!";

                
    //     //         pathStatusText.color = new Color32( 0 , 254 , 111, 255 );
    //     //         Debug.Log("You are on the right path!");
    //     //     }
            
    //     // }
        
    // }
    // void OnCollisionExit(Collision collision) {
    //     // if (collision.gameObject.name == "Guideline") {
    //     //     if (pathStatusText != null) {
    //     //         // pathStatusText.SetText("You are out of the correct path!");
    //     //         pathStatusText.text = "You are out of the correct path!";

    //     //         pathStatusText.color = new Color32( 254 , 9 , 0, 255 ) ;
    //     //         Debug.Log("You are out of the correct path!");
    //     //     }
    //     // }
    // }
}
