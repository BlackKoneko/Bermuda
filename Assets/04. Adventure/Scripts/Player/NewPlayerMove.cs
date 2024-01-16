using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewPlayerMove : MonoBehaviour
{
    float speed = 10f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vec = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            vec += transform.right*-1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vec += transform.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vec += transform.forward;// 로컬기준
        }
        if (Input.GetKey(KeyCode.S))
        {
            vec += transform.forward * -1;// 
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 2f;
        }

        vec = vec.normalized * speed;
        rb.velocity = vec;
    }
}
