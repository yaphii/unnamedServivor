using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class AchiveManager : MonoBehaviour
{
    /* 캐릭터 해금 버튼 락, 언락 */
    /* Edit > Clear All PlayersPrefs */

    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;

    //업적 을 열거형으로 표현
    enum Achive {UnlockPotato, UnlockBean}

    //업적 데이터들을 저장해둘 배열 선언 및 초기화
    Achive[] achives;

    void Awake(){
        //주어진 열거형의 데이터를 모두 가져오는 함수
        achives = (Achive[])Enum.GetValues(typeof(Achive));
        if(!PlayerPrefs.HasKey("MyData")){
            Init();
        }
    }
    
    void Init(){
        //간단한 저장기능을 제공하는 유니티 제공 클래스
        PlayerPrefs.SetInt("MyData",1);
        foreach (Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(),1);
        }
    }

    void Start()
    {
        UnlockCharacter();
    }

    void UnlockCharacter(){
        for (int i = 0; i < lockCharacter.Length ; i++)
        {
            string achiveName = achives[i].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achiveName) == 1;
            lockCharacter[i].SetActive(!isUnlock);
            unlockCharacter[i].SetActive(isUnlock);
        }
    }

    void Update()
    {
        
    }
}
