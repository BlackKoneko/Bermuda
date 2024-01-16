using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaseTrap : MonoBehaviour
{
    public float speed = 2f;
    public float limit = 75f; //Limit in degrees of the movement



    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time * speed);
        transform.localRotation = Quaternion.Euler(0, 0, angle + 180);
    }
}
