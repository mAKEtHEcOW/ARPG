using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPGCamera : MonoBehaviour
{
    public Transform target;
    public float targetHeight = 1.8f;
    public float targetSide = -0.1f;
    public float distance = 4;
    public float maxDistance = 8;
    public float minDistance = 2.2f;
    public float xSpeed = 250;
    public float ySpeed=  125;
    public float yMinLimint = -10;
    public float yMaxLimint = 72;
    public float zoomRate = 80;
    public float x = 20;
    public float y = 0;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void OnEnable()
    {
        InputControl.instence.InputEventCameraUpdate += CameraUpdate;
    }

    private void OnDisable()
    {
        InputControl.instence.InputEventCameraUpdate -= CameraUpdate;
    }

    //private void LateUpdate()
    //{
    //    //rotation计算
    //    x += moveInput.cameraVector.x * xSpeed * Time.deltaTime;
    //    y -= moveInput.cameraVector.y * xSpeed * Time.deltaTime;
    //    distance -= (moveInput.cameraVector.z * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
    //    distance = Mathf.Clamp(distance, minDistance, maxDistance);
    //    y = ClampAngle(y, yMinLimint, yMaxLimint);
    //    Quaternion rotation = Quaternion.Euler(y,x,0);
    //    transform.rotation = rotation;

    //    //rotation设置
    //    if(moveInput.cameraVector.x !=0 || moveInput.cameraVector.y != 0)
    //    {
    //        target.transform.rotation = Quaternion.Euler(0, x, 0);
    //    }
    //    //position设置
    //    transform.position = target.position - (rotation * new Vector3(targetSide, 0, 1) * distance - new Vector3(0,targetHeight,0));
    //}

    private void CameraUpdate(Vector3 cameraVector)
    {
        x += cameraVector.x * xSpeed * Time.deltaTime;
        y -= cameraVector.y * xSpeed * Time.deltaTime;
        distance -= (cameraVector.z * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        y = ClampAngle(y, yMinLimint, yMaxLimint);
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        transform.rotation = rotation;

        //rotation设置
        if (cameraVector.x != 0 || cameraVector.y != 0)
        {
            target.transform.rotation = Quaternion.Euler(0, x, 0);
        }
        //position设置
        transform.position = target.position - (rotation * new Vector3(targetSide, 0, 1) * distance - new Vector3(0, targetHeight, 0));
    }

    float ClampAngle(float angle, float min, float max)
    {
        if(angle < -360)
        {
            angle += 360;
        }
        if(angle> 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
