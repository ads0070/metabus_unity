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
	bool isBorder;

	Vector3 moveVec;
	Vector3 newDirection;
	Animator anim;

	void Awake()
	{
		anim = GetComponentInChildren<Animator>();
	}

	void StopToWall()
	{
		isBorder = Physics.Raycast(transform.position, transform.forward, 5, LayerMask.GetMask("Map"));
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

		var quaternion = Quaternion.Euler(0, centralAxis.transform.eulerAngles.y, 0);
		newDirection = quaternion * moveVec;

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
			transform.position += newDirection * speed * Time.deltaTime;
		}

		transform.LookAt(transform.position + newDirection);

		centralAxis.position = transform.position;
	}
}
