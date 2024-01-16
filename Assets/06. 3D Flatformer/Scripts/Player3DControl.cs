using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player3DControl : MonoBehaviour
{
    [SerializeField] GameObject model;
    [SerializeField] Animator animator;
    private PlayerData plData;
    private Rigidbody rb;
    public float jumpPower;
    private bool jumpCheck;
    private float distance;
    private bool isESC;
    public bool isStart;
    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        isStart = false;
        isESC = false;
        distance = 0.515f;
        plData = FindObjectOfType<PlayerData>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isStart)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                isESC = !isESC;

            if (!isESC)
            {
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                Ray ray = new Ray(this.transform.position, -transform.up);
                if (Physics.Raycast(ray, distance))
                {
                    Vector3 pos = transform.position;
                    pos.y += 0.015f;
                    transform.position = pos;
                    jumpCheck = true;
                }

                PlayerMove();
                Jump();
            }
            else
            {
                UnityEngine.Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpCheck = true;
    }

    private void PlayerMove()
    {
        Vector3 move = Vector3.zero;
        Quaternion modelRotate = Quaternion.Euler(0, 0, 0);
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
        else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
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

        if (jumpCheck)
        {
            if (move == Vector3.zero)
            {
                animator.SetInteger("animation", 15);
            }
            else
            {
                animator.SetInteger("animation", 20);
            }
        }
        else
        {
            animator.SetInteger("animation", 16);
        }

        move = move.normalized * plData.speed * 80 * Time.deltaTime;
        move.y = velocityY;
        rb.velocity = move;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCheck)
        {
            GetComponent<EffectSound>().Play();
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpCheck = false;
        }
    }
}
