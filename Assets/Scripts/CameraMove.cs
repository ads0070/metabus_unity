using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform centralAxis;
    public Transform target;
    private bool isBtnDown = false;
    private float roX;

    private float camSpeed = 3f;
    float mouseX;
    float mouseY;
    int deviceWidth = Screen.width;

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }

    void Update()
    {
        if (isBtnDown)
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y") * -1;

            if (centralAxis.rotation.x + mouseY <= -5) roX = -5;
            else if (centralAxis.rotation.x + mouseY > 7) roX = 7;
            else roX = centralAxis.rotation.x + mouseY;

            centralAxis.rotation = Quaternion.Euler(
                new Vector3(
                    roX,
                    centralAxis.rotation.y + mouseX,
                    0) * camSpeed);
        }
    }
}