using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
	Collider2D coll;
	private void Awake()
	{
		coll = GetComponent<Collider2D>();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (!collision.CompareTag("Area"))
			return;

		Vector3 playerPos = GameManager.instance.player.transform.position;
		Vector3 myPos = transform.position  ;


		//플레이어가 어떻게 사용하느냐에 따라 예외사항이 발생할 수 있어  사용하지 않음
		// Vector3 playerDir= GameManager.instance.player.inputVec;


		switch (transform.tag)
		{
			case "Ground":
		
				float diffX = playerPos.x - myPos.x; 
				float diffY = playerPos.y - myPos.y;
				float dirX = diffX < 0 ? -1 : 1;
				float dirY = diffY < 0 ? -1 : 1;

				diffX = Mathf.Abs(diffX);
				diffY = Mathf.Abs(diffY);

				if (diffX > diffY)
				{
					transform.Translate(Vector3.right * dirX * 40);
				}
				else if(diffX < diffY)
				{
					transform.Translate(Vector3.up* dirY * 40);
				}
				break;

			case "Enemy":
				if (coll.enabled)
				{
					Vector3 dist = playerPos - myPos;
					Vector3 ran = new Vector3(Random.Range(-3,3), Random.Range(-3,3), 0);
					transform.Translate(ran + dist*2);
										}
				break;

			default:
				break;
		}
		}
}

