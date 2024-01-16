using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float mouseSpeed = 0.6f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        transform.Rotate(0f, Input.GetAxis("Mouse X") * mouseSpeed, 0f, Space.World);

        /*
        if (transform.rotation.x > 90)
        {
            transform.rotation = Quaternion.Euler(90f, transform.rotation.y, transform.rotation.z);
        }
        else if (transform.rotation.x < -90)
        {
            transform.rotation = Quaternion.Euler(-90f, transform.rotation.y, transform.rotation.z);
        }*/
    }
}
