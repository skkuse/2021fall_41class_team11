using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

using LitJson;

public class SearchBooks : MonoBehaviour
{
    public GameObject SearchCube;
    public InputField input;
    public Button Button_search;
    public Transform res;

    string jsonResult;
    bool isOnLoading = true;
    //string Title;
    //string previewURL;
    int MAX = 3;

    JsonData ItemData;

    IEnumerator LoadData()
    {
        string GetDataUrl = "https://www.googleapis.com/books/v1/volumes?q=" + input.text.ToString() + "&orderBy=relevance";// + "&maxResults=10";
        Application.OpenURL(GetDataUrl);
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

                    ItemData = JsonMapper.ToObject(jsonResult);
                    for (int i = 0; i < MAX; i++)
                    {
                        string Title = ItemData["items"][i]["volumeInfo"]["title"].ToString();
                        string previewURL = ItemData["items"][i]["volumeInfo"]["previewLink"].ToString();
                        string imageURL = ItemData["items"][i]["volumeInfo"]["imageLinks"]["thumbnail"].ToString();
                        Debug.Log(Title);

                        GameObject button = Instantiate(SearchCube);
                        RectTransform btnpos = button.GetComponent<RectTransform>();
                        button.transform.position = gameObject.transform.position;
                        Image image = button.GetComponent<Image>();
                        Sprite btnsprite = Resources.Load<Sprite>(imageURL);
                        image.sprite = btnsprite;
                        btnpos.SetParent(gameObject.transform);
                        btnpos.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, (20 * i), 36);

                    }


                    //Application.OpenURL(previewURL);
                }
            }
        }
    }

    public void CreateBtn()
    {
        for (int i = 0; i < MAX; i++)
        {
            string Title = ItemData["items"][i]["volumeInfo"]["title"].ToString();
            string previewURL = ItemData["items"][i]["volumeInfo"]["previewLink"].ToString();
            string imageURL = ItemData["items"][i]["volumeInfo"]["imageLinks"]["thumbnail"].ToString();
            Debug.Log(Title);

            GameObject button = Instantiate(SearchCube);
            RectTransform btnpos = button.GetComponent<RectTransform>();
            button.transform.position = gameObject.transform.position;
            Image image = button.GetComponent<Image>();
            Sprite btnsprite = Resources.Load<Sprite>(imageURL);
            image.sprite = btnsprite;
            btnpos.SetParent(gameObject.transform);
            btnpos.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, (20 * i), 36);

        }
    }

    public void SearchButtonClick()
    {
        if (input.text.Length > 0)
        {
            Debug.Log(input.text);
            StartCoroutine(LoadData());
            //CreateBtn();
            //SceneManager.LoadScene("SearchResults");
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