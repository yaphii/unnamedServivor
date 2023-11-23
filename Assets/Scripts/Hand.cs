using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{	public bool isLeft;//ㅇㅗ른손 왼손 구ㅜㅂㄴ				public SpriteRenderer spriter;//나중에 public 필요					SpriteRenderer player;	//방향과 위치				Vector3 rightPos = new Vector3(0.35f, -0.15f, 0);//반전되기 전  			Vector3 rightPosReverse = new Vector3(-0.15f, -0.15f, 0);//반전되기 전			Quaternion leftRot = Quaternion.Euler(0, 0, -35);	Quaternion leftRotReverse = Quaternion.Euler(0, 0, -135);	private void Awake()	{		player = GetComponentsInParent<SpriteRenderer>()[1];//자기자신의 렌더러가 있으면 0, 그담은 부모 [1]									}

	private void LateUpdate()	{		//몸이 반전되었을때 손도 반전 될수 있도록 한다		bool isReverse = player.flipX;		if (isLeft)//왼손 근접무기  회전 플레이어를 기준으로 회전한다 		{			//플레이어가 바라보는 방향이 오른쪽			transform.localRotation = isReverse ? leftRotReverse : leftRot;			spriter.flipY = isReverse;			spriter.sortingOrder = isReverse ? 4 : 6;		}		else//원거리 무기 		{			transform.localPosition = isReverse ? rightPosReverse : rightPos;			spriter.flipX = isReverse;			spriter.sortingOrder = isReverse ? 6 : 4;		}	}
}
