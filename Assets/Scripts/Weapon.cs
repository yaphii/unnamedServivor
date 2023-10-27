using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;//무기ID 
    public int prefabId;//프리펩아이디
    public float damage;
    public int count;//배치할 무기 갯수
    public float speed;//회전속도    float timer;    Player player;	private void Awake()	{        //player = GetComponentInParent<Player>();        player = GameManager.instance.player;							}	public void Init(ItemData data)    {        //basic set        name = "Weapon" + data.itemId;        transform.parent = player.transform;        transform.localPosition = Vector3.zero;        //property set                                 id = data.itemId;        damage = data.baseDamage;        count = data.baseCount;        for (int index = 0; index < GameManager.instance.pool.prefabs.Length ; index++)        {            if(data.projectile == GameManager.instance.pool.prefabs[index])            {                prefabId = index;                break;            }        }        switch (id)        {            case 0:                speed = 150;//시계방향 회전                Batch();                break;            default:				speed = 0.3f;//연사 속도 						break;        }        //BroadcastMessage : 특정 함수의 호출을 모든 자식에게 방송하는 함수         player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);//플레이어가 가지고 있는 모든 기어에 applygear를 실행     }
    public void Batch()    {
        for (int i = 0; i < count ; i++)        {			//가져온 오브젝트의 transform을 지역변수로 저장  (bullet에 부모를 변경하기 위하여 ..)			//Transform bullet = GameManager.instance.pool.Get(prefabId).transform;		    Transform bullet;            //기존 오브젝트를 먼저 활용하고  모자르면 풀링에서 가져오기 .            if(i < transform.childCount)            {                bullet = transform.GetChild(i);            }            else            {				bullet = GameManager.instance.pool.Get(prefabId).transform;    			bullet.parent = transform;			}            //위치와 회전을 초기화                                         bullet.localPosition = Vector3.zero;            bullet.localRotation = Quaternion.identity;            //회전 후 자신의 위쪽 방향으로 1.5이동            Vector3 rotVec = Vector3.forward * 360 * i / count;            bullet.Rotate(rotVec);            bullet.Translate(bullet.up * 1.5f, Space.World);            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero);//-1 관통???????무한????? -1 is Infinity																				}	}

    public void LevelUp(float damage, int count )    {
        this.damage = damage;        this.count += count;        if(id == 0)        {            Batch();        }		player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);	}

    // Update is called once per frame
    void Update()
    {		switch (id)		{			case 0:                transform.Rotate(Vector3.back * speed * Time.deltaTime);        		break;						default:				timer += Time.deltaTime;                if(timer > speed)//스피드 보다 커지면 timer를 초기화 하고 발사 하기                {                    timer = 0f;                    Fire();                }				break;		}        if (Input.GetButtonDown("Jump"))        {            LevelUp(20, 5);        }	}	private void Fire()	{        if (!player.scanner.nearestTarget)            return;        //적의 방향        Vector3 targetPosition = player.scanner.nearestTarget.position;        Vector3 dir = targetPosition - transform.position;//크기까지 같이 포함한 것 .        dir = dir.normalized;        //기존 생성 로직을 활용         Transform bullet = GameManager.instance.pool.Get(prefabId).transform;        //위치는 플레이어 위치        bullet.position = transform.position;        //지정된 축을 중심으로 목표를 향해 회전         bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);        //초기        bullet.GetComponent<Bullet>().Init(damage, count , dir);	}}
