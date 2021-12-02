using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBook : MonoBehaviour
{
    public GameObject SearchCube;
    public InputField input;
    public Button Button_search;

    public void SearchButtonClick()
    {
        if (input)
        {
            Debug.Log("Search");
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