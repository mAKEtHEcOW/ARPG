using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    //定义角色控制器
    private CharacterController controller;
    //移动速度
    [SerializeField] private float walkerspeed = 4.0f;
    //定义单例模式
    public static PlayerControl instance;
    //获取输入
    InputControl moveInput;

    private void OnEnable()
    {//订阅事件
        InputControl.instence.InputEventMoveUpdate += moveVectorUpdate;
    }
    private void OnDisable()
    {//取消订阅事件
        InputControl.instence.InputEventMoveUpdate -= moveVectorUpdate;
    }

    private void Awake()
    {
        //拿单例
        instance = this;
        controller = this.GetComponent<CharacterController>();
    }

    private void moveVectorUpdate(Vector2 moveVector)
    {
        Vector3 dirction = transform.TransformDirection(moveVector.x, -1, moveVector.y);
        controller.Move(walkerspeed * dirction * Time.deltaTime);
    }
}
