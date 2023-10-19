using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    /* 몬스터를 검색할 스캐너 */
    //스캔범위
    public float scanRange;
    //어떤오브젝트를 스캔할건지 ?
    public LayerMask targetLayer;
    //스캔결과 스캔된 오브젝트의 배열
    public RaycastHit2D[] targets;
    //가까운 목표를 담을 변수
    public Transform nearestTarget;	private void FixedUpdate()	{        //CircleCastAll(캐스팅 시작 위치, 원의 반지름, 캐스팅 방향, 캐스팅 길이, 대상레이어)        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);        nearestTarget = GetNearest();							}

    Transform GetNearest() {        Transform result = null;        float diff = 100;//거        foreach (RaycastHit2D target in targets)        {            Vector3 myPos = transform.position;            Vector3 targetPos = target.transform.position;            float curDiff = Vector3.Distance(myPos, targetPos);            if(curDiff < diff) //가져온 거리가 저장된 거리보다 더 작으면 교             {				diff  = curDiff;                result = target.transform;			}                          }        return result;    }
}
