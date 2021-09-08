using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator playerAni;

    public PlayerAnimator instance;

    private void OnEnable()
    {//订阅事件
        InputControl.instence.InputEventMoveUpdate += AniUpdate;
    }

    private void OnDisable()
    {//取消订阅事件
        InputControl.instence.InputEventMoveUpdate -= AniUpdate;
    }

    private void Awake()
    {
        instance = this;
        playerAni = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    void AniUpdate(Vector2 moveVector)
    {
        playerAni.SetFloat("horizontal", Math.Abs(moveVector.x));
        playerAni.SetFloat("vertical", Math.Abs(moveVector.y));
    }
}
