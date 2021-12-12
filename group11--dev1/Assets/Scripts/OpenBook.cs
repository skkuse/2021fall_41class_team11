using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

using LitJson;



public class OpenBook : MonoBehaviour
{
    string jsonResult;
    bool isOnLoading = true;
    string Title;
    bool PdfAvailable = false;
    string pdfURL;

    public Text book_content;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadData());
        book_content.text = "";
    }
    IEnumerator LoadData() //json 문자열 받아오기
    {
        string GetDataUrl = "https://www.googleapis.com/books/v1/volumes?q=3642032257&maxResults=1";
        //artificial intelligence 라는 책 (isbn=3642032257)
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
                   // Debug.Log(ItemData["items"][0]["accessInfo"]["pdf"]["isAvailable"].ToString());
                    if(ItemData["items"][0]["accessInfo"]["pdf"]["isAvailable"].ToString()=="True"){
                        PdfAvailable=true;
                        pdfURL=ItemData["items"][0]["accessInfo"]["pdf"]["acsTokenLink"].ToString();
                    }else{
                        PdfAvailable=false;
                        pdfURL = null;
                    }
                    
                    Debug.Log(PdfAvailable);
                    Debug.Log(pdfURL);
                }
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        book_content.text = "Title : " + Title + "\nURL : " + pdfURL;
    }
}
