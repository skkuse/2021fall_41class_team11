using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

using LitJson;

public class SearchBook : MonoBehaviour
{
    public GameObject SearchCube;
    public InputField input;
    public Button Button_search;
    public GameObject SearchResults;
    public Transform res;

    string jsonResult;
    bool isOnLoading = true;
    string Title;
    bool PdfAvailable = false;
    string pdfURL;
    string previewURL;

    IEnumerator LoadData()
    {
        string GetDataUrl = "https://www.googleapis.com/books/v1/volumes?q=" + input.text.ToString() + "&orderBy=relevance";// + "&maxResults=10";
        //Application.OpenURL(GetDataUrl);
        using (UnityWebRequest www = UnityWebRequest.Get(GetDataUrl))
        {
            //www.chunkedTransfer = false;
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError) //불러오기 실패 시
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    isOnLoading = false;
                    jsonResult =
                        System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //Debug.Log(jsonResult);
                    JsonData ItemData = JsonMapper.ToObject(jsonResult);
                    Title = ItemData["items"][0]["volumeInfo"]["title"].ToString();
                    Debug.Log(Title);
                    previewURL = ItemData["items"][0]["volumeInfo"]["previewLink"].ToString();
                    Application.OpenURL(previewURL);
                }
            }
        }
    }
    public void SearchButtonClick()
    {
        if (input.text.Length > 0)
        {
            Debug.Log(input.text);
            StartCoroutine(LoadData());

            input.text = "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}