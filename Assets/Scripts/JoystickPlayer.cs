using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPointerDown;
    private bool isUpdateCameraFirst;

    public float speed = 5f;

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 tempLocalScale;

    private Vector3 tempCameraPosition;

    public Camera camera;

    public void OnPointerDown(PointerEventData eventData)
    {
        startTouchPosition = Input.mousePosition;
        isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        RunWalk(false);
    }

    void Update()
    {
        if (isPointerDown == true)
        {
            currentTouchPosition = Input.mousePosition;
            if (startTouchPosition.x < currentTouchPosition.x)
            {
                ChangeLocalScale(1);
                RunWalk(true);
                CommonHandler.player.transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
            else if (startTouchPosition.x > currentTouchPosition.x)
            {
                ChangeLocalScale(-1);
                RunWalk(true);
                CommonHandler.player.transform.Translate(Vector2.right * Time.deltaTime * -speed);
            }
        }
    }

    void LateUpdate()
    {
        if (isUpdateCameraFirst == false)
        {
            Debug.Log("asdasd");
            isUpdateCameraFirst = true;
            camera.transform.position = Vector3.Lerp(camera.transform.position,
            new Vector3(0f, 0f, -30f), 0.7f);
        }

        if (isPointerDown == true || CommonHandler.numberOfJump != 0)
        {
            tempCameraPosition = CommonHandler.player.transform.position;
            tempCameraPosition.z = -30f;
            tempCameraPosition.x = Mathf.Clamp(tempCameraPosition.x, -30f, 10f);
            camera.transform.position = tempCameraPosition;
        }
    }

    void ChangeLocalScale(int value)
    {
        tempLocalScale = CommonHandler.player.transform.localScale;
        tempLocalScale.x = value;
        CommonHandler.player.transform.localScale = tempLocalScale;
    }

    void RunWalk(bool isWalk)
    {
        CommonHandler.animatorPlayer.SetBool("Walk", isWalk);
    }
}
