using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenbookScene : MonoBehaviour
{
    public string sceneName = "Book 1";
    //마우스 터치시
    void OnMouseDown()
    {
        //씬 전환
        SceneManager.LoadScene(sceneName);
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
