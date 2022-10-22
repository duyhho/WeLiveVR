using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    public GameObject BrushGO;
    public float BrushSize = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "board")
        {
            Debug.Log("Collided with board!");
            Vector3 contactPoint = collision.contacts[0].point;

            Vector3 spawnPos = contactPoint;
            // float radius = 0.1f;

            // if (Physics.CheckSphere(spawnPos, radius))
            // {
            //     // found something
            // }
            // else
            // {
            //     // spot is empty, we can spawn
            //     //instanciate a brush
            //     var go = Instantiate(BrushGO, spawnPos, Quaternion.Euler(new Vector3(90, 0, 0)), collision.gameObject.transform);
            //     go.transform.localScale = Vector3.one * 0.01f * BrushSize;
            // }
            var go = Instantiate(BrushGO, spawnPos, Quaternion.Euler(new Vector3(90, 0, 0)), collision.gameObject.transform.parent.transform);
            go.transform.localScale = Vector3.one * 0.01f * BrushSize;

        }
    }
}
