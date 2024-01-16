using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DView : MonoBehaviour
{
    [SerializeField] private GameObject cameraArm;
    [SerializeField] private float limitMinX = -50;
    [SerializeField] private float limitMaxX = 50;
    [SerializeField] private UiManager UI;

    private float eulerAngleY;
    private float eulerAngleX;

    private void Start()
    {
        eulerAngleY = 0;
        eulerAngleX = 0;

        UI = FindObjectOfType<UiManager>();
    }

    private void Update()
    {
        if (UI.currentUI == null)
            PlayerCameraControl();
    }

    private void PlayerCameraControl()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");

        eulerAngleY += mouseX;
        eulerAngleX -= mouseY;
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(0, eulerAngleY, 0);
        cameraArm.transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
