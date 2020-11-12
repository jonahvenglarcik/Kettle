using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Reflection;

namespace Kettle.ClientAPITest 
{
    public class ClientAPITest : MonoBehaviour
    {
        // Start is called before the first frame update
        private static string baseUrl = "https://kettlex-server.herokuapp.com/";
        private string getUrl = baseUrl + "user/?UserName=rrr10";
        private string postUrl = baseUrl + "user/createCS";

        void Start()
        {
            //StartCoroutine(Get(getUrl));

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

        

        public static IEnumerator Get(string url, System.Action<string> result)
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
                        if (result != null) 
                        {
                            var strResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                            // result(www.downloadHandler.text);
                            result(strResult);
                        }
                        

                        //UserResponse userRes = JsonConvert.DeserializeObject<UserResponse>(result);

                    }
                    else
                    {
                        //handle the problem
                        Debug.Log(www.error);
                        if (result != null)
                        {
                            result(www.error);
                        }
                        
                        
                    }
                }
            }

        }
        public static IEnumerator Post(string url, string jsonData)
        {
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
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

    
}

