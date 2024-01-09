using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//enemy 
	public float speed;
	public float health;//현재의 체력 , danamge가 소수점으로 들어올 수 있음 , ,

	//우리가 주입해야할 최대 체력
	public float maxHealth;
	public RuntimeAnimatorController[] animCon;
    Animator anim;
    Rigidbody2D rigid;
    Collider2D coll;
    SpriteRenderer spriter;
    bool isLive ;

    //player 
    public Rigidbody2D target;

    WaitForFixedUpdate wait;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

		anim =  GetComponent<Animator>();
		spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GameManager.instance.isLive)
			return;

        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            return;

        //가야할 방향 
        Vector2 dirVec = target.position - rigid.position;

        //다음위치 
        Vector2 nextVec = dirVec.normalized * speed * Time.deltaTime;

        //플레이어의 키입력값을 더한 이동 = 몬스터의 방향값을 더한 이
        rigid.MovePosition(rigid.position + nextVec);
        //물리속도 가 이동에 영향을 주지않도록 속도를 제거 (부딫히면 튕겨나가지 않도록 )
        rigid.velocity = Vector2.zero;
    }

	private void LateUpdate()
	{
        if(!GameManager.instance.isLive)
			return;
       
        spriter.flipX = target.position.x < rigid.position.x;
							}
	private void OnEnable()//생존여부와 체력 초기화   
	{
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
		coll.enabled = true;//collider 컴포넌트의 비활성화  
		rigid.simulated = true;//리지드바디의 물리적 비활성화 = false
		spriter.sortingOrder = 2;
		anim.SetBool("Dead", false);
		health = maxHealth;
	}

	//Spawner의 Spawn Data를 받을 수 있도록 초기 속성을 적용하는 함수
	public void Init(SpawnData data)
	{
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        //maxHealth가 변경되었기때문에 현재 체력 도 똑같이 변경
        health = data.health;
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{   //collision = 충돌한 상대
        if ( !collision.CompareTag("Bullet") || !isLive )//죽었을때는 실행하지 않
            return;

        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());
        if(health > 0)//살아있다   
        {
            anim.SetTrigger("Hit");
            AudioManager.instance.PlaySfx( AudioManager.Sfx.Hit );
        }
        else//죽었다 
        {
            isLive = false;
            coll.enabled=false;//collider 컴포넌트의 비활성화  
            rigid.simulated = false;//리지드바디의 물리적 비활성화 = false
            spriter.sortingOrder = 1;
		    anim.SetBool("Dead",true);
            GameManager.instance.kill++;
            GameManager.instance.GetExp();
            
            if(GameManager.instance.isLive)
                AudioManager.instance.PlaySfx( AudioManager.Sfx.Dead );
			
            //Dead();
        }
	}

    IEnumerator KnockBack()
    {
        //yield return null;//1프레임 쉰다 

        //yield return new WaitForSeconds(2f);//2초 쉬

        //하나의 물리 프레임을 딜레이 
        yield return wait;
        //플레이어의 위치와 반대되는 방향으로 쓰러트리기
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);//순간적 힘 이므로 Impulse
	}

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
