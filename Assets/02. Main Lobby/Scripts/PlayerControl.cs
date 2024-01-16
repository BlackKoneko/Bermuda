using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] PlayerData plData;
    [SerializeField] Animator animator;
    [SerializeField] GameObject model;

    private Rigidbody rb;
    public float speed;
    private bool isESC;
    public bool isStart;


    private void Start()
    {
        isStart = true;
        isESC = false;
        plData = FindObjectOfType<PlayerData>();
        rb = GetComponent<Rigidbody>();
        speed = 750;
    }

    private void Update()
    {
        if (isStart)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                isESC = !isESC;

            if (!isESC)
            {
                Cursor.lockState = CursorLockMode.Locked;
                PlayerMove();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    void PlayerMove()
    {
        Vector3 move = Vector3.zero;
        float velocityY = rb.velocity.y;

        if (Input.GetKey(KeyCode.W))
        {
            move += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move -= transform.right;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            model.transform.localRotation = Quaternion.Euler(0f, -45f, 0f);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            model.transform.localRotation = Quaternion.Euler(0f, 45f, 0f);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            model.transform.localRotation = Quaternion.Euler(0f, -135f, 0f);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            model.transform.localRotation = Quaternion.Euler(0f, 135f, 0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            model.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            model.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            model.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
            model.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (move == Vector3.zero)
        {
            animator.SetInteger("animation", 15);
        }
        else
        {
            animator.SetInteger("animation", 20);
        }

        move = move.normalized * speed * Time.deltaTime;
        move.y = velocityY;
        rb.velocity = move;
    }
}
