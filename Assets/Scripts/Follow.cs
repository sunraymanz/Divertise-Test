using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    void CameraMove() 
    {
        //check X position of target if camera need to move
        if (target.position.x > -1 && target.position.x < 12)
        {
            //Camera change X pos
            transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        }
        //check Y position of target if camera need to move
        if (target.position.y > 0 && target.position.y < 3)
        {
            //Camera change Y pos
            transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
        }
    }
}
