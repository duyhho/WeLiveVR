using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class Lite6APIRequest : MonoBehaviour
{
    public Transform rightController;
    private IEnumerator coroutine;
    Vector3 currentPosition = new Vector3 (0f, 0f, 0f);
    Vector3 currentRotation = new Vector3 (0f, 0f, 0f);

    Vector3 tempCoor = new Vector3 (0f, 0f, 0f);
    Vector3 tempRotation = new Vector3 (0f, 0f, 0f);


    void Start()
    {
        // A correct website page.
        // StartCoroutine("CallEveryXSeconds", 1f);
        // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));

        // StartCoroutine("CallEveryXSeconds", 1f); //call this to scale the positions;

        StartCoroutine(PickUpTrocar());

    }
    void Update() {
       
    }
    IEnumerator PickUpTrocar()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        // StartCoroutine(GetRequest("http://192.168.0.217:5000/trocar/pickup"));

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        StartCoroutine("CallEveryXSeconds", 1f);

    }
    private IEnumerator CallEveryXSeconds(int numSeconds) {
        while (true) {
            yield return new WaitForSeconds(numSeconds);
            /* Positional Arguments
            y of controller = z of lite6: 200f
            x of controller = y of lite6: -150f
            z of controller = x of lite6: 
            */
            //old way
            // Vector3 coor = new Vector3(rightController.localPosition.z * 200f, rightController.localPosition.x * -250f, rightController.localPosition.y * 200f); 
            // Debug.Log(coor);
            // Vector3 initialPosition = new Vector3(200f, 0, 200f) + coor;
            // Vector3 newRobotPosition = initialPosition;

            //new way
            // Vector3 coor = new Vector3(rightController.localPosition.z * 200f, rightController.localPosition.x * -250f, rightController.localPosition.y * 200f); 
            // Vector3 coor = new Vector3(rightController.localPosition.y * 200f, 0f, 0f); 
            // Vector3 coor = new Vector3(0f, 0f, -rightController.localPosition.z * 200f); 
            Vector3 coor = new Vector3(rightController.localPosition.y * 200f, rightController.localPosition.x * -270f, -rightController.localPosition.z * 280f); 



            Debug.Log("coor: " + coor);
            

            Vector3 positionDelta = coor - currentPosition;
            tempCoor = coor;
            Vector3 newRobotPosition = positionDelta;
            // Vector3 newRobotPosition = new Vector3(0f, 0f, 0f); //if we want to isolate rotation, set delta to 0f for position

            Debug.Log("positionDelta: " + positionDelta);

            /* Positional Arguments
            y of controller = z of lite6: 200f
            x of controller = y of lite6: -150f
            z of controller = x of lite6: 
            */

            Vector3 eulerAngles = rightController.eulerAngles - new Vector3(0f, 100f, 270f);
            // Vector3 eulerAngles = rightController.eulerAngles - new Vector3(0f, 100f, 270f);

            Debug.Log("localRotation: " + eulerAngles);

            // Vector3 rotation = new Vector3(0f, 0f, -eulerAngles[2]); //okay
            // Vector3 rotation = new Vector3(-eulerAngles[1]*0.9f, 0f, 0f); //okay

            float eulerAngleX = eulerAngles[0];
            float deltaAngleX = eulerAngleX - currentRotation[0];
            if (currentRotation[0] > 270 && eulerAngleX < 90) { //clockwise
                deltaAngleX = eulerAngleX + 360 - currentRotation[0];
            }
            else if (currentRotation[0] < 90 && eulerAngleX > 270) { //counter-clockwise
                deltaAngleX = eulerAngleX - (currentRotation[0]+360);
            }
            else {

            }
            if (deltaAngleX >= 90f) {
                deltaAngleX = 90f;
            }
            else if (deltaAngleX <= -90f) {
                deltaAngleX = -90f;
            }
            // Vector3 rotation = new Vector3(0f,  -deltaAngleX*0.6f , 0f); //okay

            Vector3 rotation = new Vector3(-eulerAngles[1]*0.9f, -deltaAngleX*0.6f, -eulerAngles[2]*0.8f); //combo 3
            Debug.Log("rotation: " + rotation);
            Debug.Log("currentRotation: " + currentRotation);



            Vector3 rotationDelta = rotation - currentRotation;
            tempRotation = rotation;
            Debug.Log("Rotation Delta:" + rotationDelta);
            Vector3 newRobotRotation = rotationDelta;
            // Vector3 newRobotRotation = new Vector3(0f, 0f, 0f);


            string APIURL = string.Format("http://192.168.0.217:5000/move?x={0}&y={1}&z={2}&Rx={3}&Ry={4}&Rz={5}", 
                    newRobotPosition[0], newRobotPosition[1], newRobotPosition[2],
                    newRobotRotation[0], newRobotRotation[1], newRobotRotation[2]); //y and x of lite6 are opposite to controller
            //  coroutine = Capture("http://127.0.0.1:5000", metricText);
            coroutine = GetRequest(APIURL);

            StartCoroutine(coroutine);
         }
    }

    IEnumerator GetRequest(string uri)
    {
        // yield return new WaitForSeconds(1f);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    string status = webRequest.downloadHandler.text;
                    if (status.ToLower() == "busy") {
                        Debug.Log("Arm Busy: Not Updating Current Position + Rotation!");
                    }
                    else {
                        currentPosition = tempCoor;
                        currentRotation = tempRotation;
                    }
                    break;
            }
        }
    }
    void OnApplicationQuit()
    {
        
        Debug.Log("Application ending after " + Time.time + " seconds");
        // StartCoroutine(GetRequest("http://192.168.0.217:5000/trocar/replace"));
        StartCoroutine(GetRequest("http://192.168.0.217:5000/reset")); //call this to scale positions;


    }
}