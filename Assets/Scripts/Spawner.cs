using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    int level;    float timer;	public SpawnData[] spawnData;	private void Awake()	{        spawnPoint = GetComponentsInChildren<Transform>();    }    // Update is called once per frame	void Update()
    {
        timer += Time.deltaTime;
        //level = Mathf.FloorToInt(GameManager.instance.gameTime / 10f);
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length-1);

        if(timer > spawnData[level].spawnTime){
            //GameManager.instance.pool.Get(1);            timer = 0;            Spawn();        }
	}
		void Spawn()        {
            GameObject enemy = GameManager.instance.pool.Get(0 );            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;            enemy.GetComponent<Enemy>().Init(spawnData[level]);        }
}
[System.Serializable]//스트라이프 타입, 소환시간, 체력, 속도 
public class SpawnData{
    public float spawnTime;    public int spriteType;    public int health;    public float speed;}