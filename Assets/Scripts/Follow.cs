using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rect;	private void Awake()	{        rect = GetComponent<RectTransform>();							}

    // Update is called once per frame
    void FixedUpdate()
    {		//월드좌표와 스크린좌표는 다르기때문에 아래와 같이 하면 안된다 		//rect.position = GameManager.instance.player.transform.position;		//WorldToScreenPoint : 월드 상의 위치를 스크린 좌표로 변환		rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position)			;	}
}
