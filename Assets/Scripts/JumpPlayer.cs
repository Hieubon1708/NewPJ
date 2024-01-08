using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpPlayer : MonoBehaviour, IPointerDownHandler
{
    public float jumpForce = 5f;

    private bool isTouch;

    private int frameCount;

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
        if (CommonHandler.CheckCollision() == false || CommonHandler.numberOfJump < 2)
        {
            CommonHandler.numberOfJump++;
            RunJump(true);
            CommonHandler.rigidbodyPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        if (isTouch == true)
        {
            frameCount++;
            if (frameCount == 2)
            {
                isTouch = false;
                RunJump(false);
                frameCount = 0;
            }
        }
    }

    void RunJump(bool isJump)
    {
        CommonHandler.animatorPlayer.SetBool("Jump", isJump);
    }
}
