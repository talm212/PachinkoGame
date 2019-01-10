using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handel : MonoBehaviour
{

    public float rotSpeed = 20;
    private float objectAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnMouseDrag()
    {
        //float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        objectAngle = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        //transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.right, objectAngle);


        //Debug.Log(transform.eulerAngles);
        //if (transform.eulerAngles.y == 0 && transform.eulerAngles.x < 270)
        //{ 
        //    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        //}

        //if (transform.eulerAngles.y == 180 && (!(transform.eulerAngles.x < 270) || !(transform.eulerAngles.x < 280)))
        //{
        //    transform.eulerAngles = new Vector3(280, transform.eulerAngles.y, transform.eulerAngles.z);
        //}

    }

}
