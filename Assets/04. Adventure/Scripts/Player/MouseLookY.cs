using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookY : MonoBehaviour
{
    private float mouseSpeed = 0.6f;
    float MaxX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Input.GetAxis("Mouse Y") * mouseSpeed, 0f, 0f);

    }
}
