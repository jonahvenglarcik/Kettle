using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Reflection;


public class ClientAPITest : MonoBehaviour
{
    // Start is called before the first frame update
    private string getUrl = "http://localhost:3000/user/?UserName=rrr10";
    private string postUrl = "http://localhost:3000/user/createCS"; 

    void Start()
    {
        StartCoroutine(Get(getUrl));

        //LocationResponse location = new LocationResponse();
        //location.Latitude = 150.111F;
        //location.Longitude = 55.010F;


        //UserResponse user = new UserResponse()
        //{
        //    RealName = "Reto",
        //    UserName = "r98",
        //    Location = location
        //};
        //string jsonData = JsonConvert.SerializeObject(user);
        //Debug.Log(jsonData);
        //StartCoroutine(Post(postUrl, jsonData));
    }

    public IEnumerator Get(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    // handle the result
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(result);

                    UserResponse userRes = JsonConvert.DeserializeObject<UserResponse>(result);
                    Debug.Log("Fields: " + userRes.RealName + ", " + userRes.UserName + ", "); //+
                       // userRes.Location.Latitude + ", " + userRes.Location.Longitude + "\n");
                    
                }
                else
                {
                    //handle the problem
                    Debug.Log("Error! Couldn't GET data.");
                }
            }
        }

    }
    public IEnumerator Post(string url, string jsonData)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {
            Debug.Log("All OK");
            Debug.Log("Status Code: " + request.responseCode);
        }
    }
}
