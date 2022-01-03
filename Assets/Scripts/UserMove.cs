using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UserMove : MonoBehaviour
{

	public float speed;
	public float v;
	public float h;
	public bl_Joystick Joystick;//Joystick reference for assign in inspector

	Vector3 moveVec;
	Animator anim;

	void Awake()
	{
		anim = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		v = Joystick.Vertical; //get the vertical value of joystick
		h = Joystick.Horizontal; //get the horizontal value of joystick

		moveVec = new Vector3(h, 0, v).normalized;

		transform.position += moveVec * speed * Time.deltaTime;

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
		

		transform.LookAt(transform.position + moveVec);

	}
}
