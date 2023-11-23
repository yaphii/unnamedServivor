using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{	public Vector2 inputVec;	public Rigidbody2D rigid;	public float speed;	public SpriteRenderer sr;	Animator anim;	public Scanner scanner;	public Hand[] hands;	private void Awake()	{		rigid = GetComponent<Rigidbody2D>();		sr = GetComponent<SpriteRenderer>();		anim = GetComponent<Animator>();		scanner = GetComponent<Scanner>();		hands = GetComponentsInChildren<Hand>(true);	}	private void FixedUpdate()	{		//1.		//rigid.AddForce(inputVec);		//rigid.velocity = inputVec;		//Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;		Vector2 nextVec = inputVec  * speed * Time.fixedDeltaTime;		rigid.MovePosition(rigid.position + nextVec);				}
	private void OnMove(InputValue value)	{		inputVec = value.Get<Vector2>();	}

	private void LateUpdate()	{		anim.SetFloat("Speed", inputVec.magnitude);//백터의 크기 		if (inputVec.x != 0)		{			sr.flipX = inputVec.x < 0;		}							}
}
