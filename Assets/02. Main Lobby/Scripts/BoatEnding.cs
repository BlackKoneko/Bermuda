using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatEnding : MonoBehaviour
{
    public float boatSpeed;
    // Start is called before the first frame update
    void Start()
    {
        boatSpeed = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * -boatSpeed);
    }
}
