using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool isJumping;
    public int gameHp;
    public float moveSpeed;
    public PlayerData playerData;
    public bool isCheck;
    private float RotateSpeed;
    public bool isInvisible;



    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        gameHp = playerData.hp;
        moveSpeed = 2f;
        rigidbody = GetComponent<Rigidbody>();
        transform.position = Vector3.up * 5 + Vector3.forward * 75 + Vector3.right * -12;
        isJumping = false;
        isCheck = false;
        RotateSpeed = 250f;
        isInvisible = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -RotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rigidbody.AddForce(Vector3.up * 3.5f, ForceMode.Impulse);
        }
        else
        {
            return;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
