using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform centralAxis;
    public Transform target;
    public Vector3 offset;

    public float camSpeed = 10f;
    float mouseX;
    float mouseY;
    int deviceWidth = Screen.width;

    void CamMove()
    {
        if (Input.GetMouseButton(0))
        {
            if (deviceWidth/2 < Input.mousePosition.x)
            {
                mouseX += Input.GetAxis("Mouse X");
                mouseY += Input.GetAxis("Mouse Y") * -1;

                centralAxis.rotation = Quaternion.Euler(
                    new Vector3(
                        centralAxis.rotation.x + mouseY,
                        centralAxis.rotation.y + mouseX,
                        0) * camSpeed);
            }
        }
    }

    void CamFollow()
    {
        centralAxis.position = target.position;
    }

    void Update()
    {
        CamMove();
        CamFollow();
    }
}
