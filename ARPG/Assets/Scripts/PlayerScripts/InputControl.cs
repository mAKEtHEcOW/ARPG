using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputControl : MonoBehaviour
{
    public Vector3 cameraVector;
    public Vector2 moveVector;
    //单实例
    public static InputControl instence;

    public event UnityAction<Vector2> InputEventMoveUpdate;
    public event UnityAction<Vector3> InputEventCameraUpdate;

    private void Awake()
    {//获取单实例
        instence = this;
    }

    void Update()
    {
        moveVector.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //发布移动事件
        InputEventMoveUpdate(moveVector);
    }

    private void LateUpdate()
    {
        cameraVector.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse ScrollWheel"));
        InputEventCameraUpdate(cameraVector);
    }
}
