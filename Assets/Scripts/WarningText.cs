using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningText : MonoBehaviour
{
    [SerializeField]GameObject textToken;
    float time = 0;

    private void Start()
    {
        textToken.GetComponent<TextMesh>().color = Color.blue;
        ShowWarning("Press E to Interact with object");
    }

    private void FixedUpdate()
    {
        //if already show. reduce time until 0
        if (time <= 0)
        {
            HideWarning();
        }
        else { time -= Time.deltaTime; }
    }

    public void ShowWarning(string str) 
    {
        textToken.SetActive(true);      
        textToken.GetComponent<TextMesh>().text = str;
        time = 3f;
    }
    void HideWarning() 
    {
        textToken.SetActive(false);
        textToken.GetComponent<TextMesh>().color = Color.red;
    }
}
