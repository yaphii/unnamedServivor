using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	public Vector2 inputVec;
	public Rigidbody2D rigid;
	public float speed;
	public SpriteRenderer sr;
	Animator anim;
	public Scanner scanner;

	public Hand[] hands;
	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		scanner = GetComponent<Scanner>();
		hands = GetComponentsInChildren<Hand>(true);
	}

	void Update(){
		if(!GameManager.instance.isLive){
			return;
		}
		inputVec.x = Input.GetAxisRaw("Horizontal");
		inputVec.y = Input.GetAxisRaw("Vertical");

	}
	private void FixedUpdate()
	{
		if(!GameManager.instance.isLive){
			return;
		}
		//1.
		//rigid.AddForce(inputVec);
		//rigid.velocity = inputVec;
		//Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
		Vector2 nextVec = inputVec  * speed * Time.fixedDeltaTime;
		rigid.MovePosition(rigid.position + nextVec);
			

	}
	private void OnMove(InputValue value)
	{
		inputVec = value.Get<Vector2>();
	}

	private void LateUpdate()
	{
		if(!GameManager.instance.isLive){
			return;
		}
		
		anim.SetFloat("Speed", inputVec.magnitude);//백터의 크기 
		if (inputVec.x != 0)
		{
			sr.flipX = inputVec.x < 0;
		}


	}

	//몬스터랑 부딫히면 계속해서 피를 깎아먹음.
	void OnCollisionStay2D(Collision2D collision){
		if(!GameManager.instance.isLive)//죽었으면 안깎임
			return;

		GameManager.instance.health -= Time.deltaTime * 10;

		//플레이어의 사망
		if(GameManager.instance.health < 0){
			// 플레이어가 가지고 있는 자식들 비활성화
			for (int i = 2; i < transform.childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
			
			//플레이어의 죽는 에니메이션 재생
			anim.SetTrigger("Dead");
		}
	}
}
