using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back_to_book : MonoBehaviour
{
    public string sceneName1 = "Book 1";
    //마우스 터치시
    void OnMouseDown()
    {
        //씬 전환
        SceneManager.LoadScene(sceneName1);
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
