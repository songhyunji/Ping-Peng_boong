﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class JsonAdapter : MonoBehaviour
{
    
    public static event Action<bool> GET;
    public static event Action<bool> POST;
    public IEnumerator API_GET(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(PrivateData.ec2+url);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            if(www.responseCode != 200)
            {
                Debug.Log("already exist");
                GET?.Invoke(false);
            }
            else
            {
                Debug.Log("add account");
                GET?.Invoke(true);
            }
            //GET.Invoke(JsonHelper.fixJson(www.downloadHandler.text));


            // Or retrieve results as binary data
            /*byte[] results = www.downloadHandler.data;

           


            string fixdata = JsonHelper.fixJson(www.downloadHandler.text);
            JsonData[] datas = JsonHelper.FromJson<JsonData>(fixdata);
           
            Debug.Log(datas.Length);*/
            yield break;

        }
    }
    
    public IEnumerator API_POST(string url , string bodyJsonString)
    {
        Debug.Log(bodyJsonString);
        var req = new UnityWebRequest(PrivateData.ec2 + url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(bodyJsonString);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.Send();

        if(req.isHttpError || req.isNetworkError )
        {
            Debug.Log(req.error);
            POST?.Invoke(false);
        }
        else if(req.responseCode != 200)
        {
           
            POST?.Invoke(false);
        }
        else
        {
            POST?.Invoke(true);
        }
       
        Debug.Log("Status Code: " + req.responseCode);

        yield break;
    }

}
[Serializable]
public class Chat
{
    public string id_1;
    public string id_2;
    public string text;
    public DateTime time;

    public Chat(string i1,string i2,string txt)
    {
        id_1 = i1;
        id_2 = i2;
        text = txt;
        time = DateTime.Now;
    }
}
[Serializable]
public class FriendRequest
{
    public string id;
    public string friend_id;

    public FriendRequest(string i, string f)
    {
        id = i;
        friend_id = f;
    }
}
[Serializable]
public class UserData
{
    public string id;
    public int cash;
    public string nickname;
    public int stage;
    //public int change;
}
[Serializable]
public class StageData
{
    public string id;
    public int stage_num;
    public int stage_step;

    public StageData(string i , int num)
    {
        id = i;
        stage_num = num;
        stage_step = 99;
    }
}




public class UserSkinData
{
	public int rid;
	public string userid;
	public int skinid_1;
	public Time gettime_1;
	public int skinid_2;
	public Time gettime_2;
	public int skinid_3;
	public Time gettime_3;
	public int skinid_4;
	public Time gettime_4;
	public int skinid_5;
	public Time gettime_5;
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        Debug.Log(wrapper.Items.Length);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }
    public static string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }


}