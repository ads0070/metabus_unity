using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UserMove : MonoBehaviour
{

    private float speed;
    private float v;
    private float h;
    public bl_Joystick Joystick;
    public Transform centralAxis;
    private Rigidbody rigidbody;
    bool isBorder;

    Vector3 moveVec;
    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void StopToWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        isBorder = Physics.Raycast(transform.position, transform.forward, 5, LayerMask.GetMask("Wall_1"));
    }

    void FixedUpdate()
    {
        StopToWall();
    }

    void Update()
    {
        v = Joystick.Vertical;
        h = Joystick.Horizontal;

        moveVec = new Vector3(h, 0, v).normalized;

        Debug.Log(centralAxis.transform.eulerAngles);

        if (moveVec != Vector3.zero)
        {
            if (System.Math.Abs(v) < 2.5 && System.Math.Abs(h) < 2.5)
            {
                anim.SetBool("isRun", false);
                anim.SetBool("isWalk", true);
                speed = 15;
            }
            else
            {
                anim.SetBool("isRun", true);
                anim.SetBool("isWalk", false);
                speed = 30;
            }
        }
        else
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isWalk", false);
        }

        if (!isBorder)
        {
            transform.position += moveVec * speed * Time.deltaTime;

        }

        transform.LookAt(transform.position + moveVec);

        centralAxis.position = transform.position;

    }

}