using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackPlayer : MonoBehaviour, IPointerDownHandler
{
    private bool isAttack;
    private bool isTouch;

    private int frameCount;

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
        if (CommonHandler.CheckCollision() == false)
        {
            RunAttack(true);
        }
        else
        {
            RunJumpAttack(true);
        }
    }

    void Update()
    {
        if (isTouch == true)
        {
            frameCount++;
            if (frameCount == 6)
            {
                RunAttack(false);
                RunJumpAttack(false);
                frameCount = 0;
                isTouch = false;
            }
        }
    }

    void RunAttack(bool isAttack)
    {
        CommonHandler.animatorPlayer.SetBool("Attack", isAttack);
    }
    
    void RunJumpAttack(bool isAttack)
    {
        CommonHandler.animatorPlayer.SetBool("JumpAttack", isAttack);
    }
}
