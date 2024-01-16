using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool isJumping;
    public int hp;
    public float moveSpeed;
    private float speedUp = 0.05f;
    void Start()
    {
        hp = 50;
        moveSpeed = 0.05f;
        rigidbody = GetComponent<Rigidbody>();
        transform.position = Vector3.up * 5;
        isJumping = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -0.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 0.5f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed, Space.Self);
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
            rigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedUpItem")
        {
            float time = 5;
            moveSpeed += speedUp;
            Destroy(other.gameObject);
            while (time > 0)
            {
                time -= Time.deltaTime;
            }
            if (time == 0)
            {
                moveSpeed -= speedUp;
            }
        }
        if (other.tag == "HpUp")
        {
            hp += 5;
        }
    }
}
