using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    public GameObject iconToken;
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (iconToken.active)
        {
            transform.localPosition = new Vector2(target.transform.position.x,target.transform.position.y-3f);
        }
    }

    public void SetUI(GameObject obj, bool b) 
    {
        //show interact UI and attached to the target
        iconToken.SetActive(b);
        target = obj;
    }
}
