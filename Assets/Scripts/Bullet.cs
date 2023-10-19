using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   //damage, 관통력 두가지 변수 필요 
    public float damage;
    public int per ;	/*per	 * 근접 공격과 원거리를 나누는 역할과 동시에 원거리 총알은 몇 번 관통하는지 알려주는 지표로 사용됩니다	 * 영상에서는 근접무기의 per 를 -1로 했는데, 	 * 이것 때문에 Bullet 스크립트에서 per == -1 조건을 통해 	 * 근접무기가 몬스터에 닿아도 사라지지않게 로직을 나눠뒀습니다. 	 * 반대로 per가 높으면 적을 관통하면서 per가 하나씩 줄어들고 마침내 0이 되면 	 * 총알이 비활성화되어 사라지는 것이지요. 	 * 참고로 16화에서는 per 를 -100으로 바꾸어 	 * 근접무기와 원거리 총알의 역할이 겹치는 오류를 방지했으니 	 * 가급적이면 근접무기 표현을 per  == -100으로 해주세요.	 */																																																																																										Rigidbody2D rb;	private void Awake()	{        rb = GetComponent<Rigidbody2D>();							}	public void Init(float damage, int per, Vector3 dir)    {
        this.damage = damage;        this.per = per;        if(per > -1)//원거리 무기인지 판        {            rb.velocity = dir * 15f;        }    }	private void OnTriggerEnter2D(Collider2D collision)	{		//근접무기 이거나 몬스터일 경우에만         if (!collision.CompareTag("Enemy") || per == -1)             return;        per--;        if(per == -1)        {            rb.velocity = Vector2.zero;            gameObject.SetActive(false);        }							}
}
