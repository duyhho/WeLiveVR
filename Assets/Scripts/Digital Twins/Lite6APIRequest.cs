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
    void Start()
    {
        // A correct website page.
        // StartCoroutine(GetRequest("http://192.168.0.217:5000/move?x=266&y=0&z=154"));
        StartCoroutine("CallEveryXSeconds", 1f);
        // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));
    }
    void Update() {
        // Vector3 coor = rightController.position;
        // Vector3 initialPosition = new Vector3(200f, 0, 200f);
        // Vector3 newRobotPosition = initialPosition + coor * 100f;
        // string APIURL = string.Format("http://192.168.0.217:5000/move?x={0}&y={1}&z={2}", newRobotPosition[0], newRobotPosition[1], newRobotPosition[2]);
        // StartCoroutine(GetRequest(APIURL));
    }
    private IEnumerator CallEveryXSeconds(int numSeconds) {
        while (true) {
            yield return new WaitForSeconds(numSeconds);
            /* 
            y of controller = z of lite6: 200f
            x of controller = y of lite6: -150f
            z of controller = x of lite6: 
            */
            Vector3 coor = new Vector3(rightController.localPosition.z * 200f, rightController.localPosition.x * -250f, rightController.localPosition.y * 200f); 
            Debug.Log(coor);
            Vector3 initialPosition = new Vector3(200f, 0, 200f) + coor;
            Vector3 newRobotPosition = initialPosition;
            string APIURL = string.Format("http://192.168.0.217:5000/move?x={0}&y={1}&z={2}", newRobotPosition[0], newRobotPosition[1], newRobotPosition[2]); //y and x of lite6 are opposite to controller
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
                    break;
            }
        }
    }
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        StartCoroutine(GetRequest("http://192.168.0.217:5000/reset"));

    }
}