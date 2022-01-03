using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UserMove : MonoBehaviour
{

	public float speed;
	float hAxis;
	float vAxis;
	bool wDown;
	public bl_Joystick Joystick;//Joystick reference for assign in inspector

	Vector3 moveVec;
	Animator anim;

	void Awake()
	{
		anim = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		//hAxis = Input.GetAxisRaw("Horizontal");
		//vAxis = Input.GetAxisRaw("Vertical");
		float v = Joystick.Vertical; //get the vertical value of joystick
		float h = Joystick.Horizontal;//get the horizontal value of joystick
		wDown = Input.GetButton("Walk");

		//moveVec = new Vector3(hAxis, 0, vAxis).normalized;
		moveVec = new Vector3(h, 0, v).normalized;

		transform.position += moveVec * speed * Time.deltaTime;

		anim.SetBool("isRun", moveVec != Vector3.zero);
		anim.SetBool("isWalk", wDown);

		transform.LookAt(transform.position + moveVec);

	}
}
