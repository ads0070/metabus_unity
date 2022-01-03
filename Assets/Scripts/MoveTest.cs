using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MoveTest : MonoBehaviour
{

	public float speed;
	float hAxis;
	float vAxis;
	bool rDown;

	Vector3 moveVec;
	Animator anim;

	void Awake()
	{
		anim = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		hAxis = Input.GetAxisRaw("Horizontal");
		vAxis = Input.GetAxisRaw("Vertical");
		rDown = Input.GetButton("Run");

		moveVec = new Vector3(hAxis, 0, vAxis).normalized;

		transform.position += moveVec * speed * Time.deltaTime;

		anim.SetBool("isWalk", moveVec != Vector3.zero);
		anim.SetBool("isRun", rDown);

		transform.LookAt(transform.position + moveVec);

	}
}
