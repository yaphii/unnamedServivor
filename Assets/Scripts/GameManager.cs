using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;    [Header("# Game Object")]    public Player player;    public PoolManager pool;    [Header("# Game Control")]	//소환레벨 적용하기	public float gameTime;    public float maxGameTime = 2*10f;	[Header("# Player Info")]	//킬수  레벨  경험치	public int kill;    public int level;    public int exp ;    //각 레벨별 필요 경험를 보관할 배열변    //public int[] nextExp = { 10,30,60,100,150,210,280,360,450,600};    public int[] nextExp = { 3,5,10,100,150,210,280,360,450,600};    private void Awake()	{		instance = this;	}	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)        {            gameTime = maxGameTime;                          }
    }

    public void GetExp()    {
        exp++;
        if(exp == nextExp[level])        {
            level++; //level을 올리고 경험치는 초기화            exp = 0;        }
    }
}
