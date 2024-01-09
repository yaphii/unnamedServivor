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
    public GameObject uiNotice;

    //업적 을 열거형으로 표현
    enum Achive {UnlockPotato, UnlockBean}

    //업적 데이터들을 저장해둘 배열 선언 및 초기화
    Achive[] achives;
    WaitForSecondsRealtime wait;
    void Awake(){
        //주어진 열거형의 데이터를 모두 가져오는 함수
        achives = (Achive[])Enum.GetValues(typeof(Achive));
        wait=new WaitForSecondsRealtime(5);
        if(!PlayerPrefs.HasKey("MyData")){
            Init();
        }
    }
    
    void Init(){
        //간단한 저장기능을 제공하는 유니티 제공 클래스
        PlayerPrefs.SetInt("MyData",1);
        foreach (Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(),0);
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

    //업적달성을 확인
    void LateUpdate()
    {
        foreach (Achive achive in achives)
        {
            CheckAchive(achive);
        }
    }

    void CheckAchive(Achive achive){
        bool isAchive = false;
        //어느 업적인지?
        switch(achive){
            case Achive.UnlockPotato:
                isAchive = (GameManager.instance.kill >= 10);
                break;

            case Achive.UnlockBean:
                isAchive = (GameManager.instance.gameTime == GameManager.instance.maxGameTime);
                break;
        }

        if(isAchive && PlayerPrefs.GetInt(achive.ToString())==0){
            PlayerPrefs.SetInt(achive.ToString(),1);


            for (int i = 0; i < uiNotice.transform.childCount; i++)
            {
                bool isActive = i == (int)achive;
                uiNotice.transform.GetChild(i).gameObject.SetActive(isActive);
            }
            StartCoroutine(NoticeRoutine());
        }
    }

    IEnumerator NoticeRoutine(){
        uiNotice.SetActive(true);
        AudioManager.instance.PlaySfx( AudioManager.Sfx.LevelUp );
        yield return wait;
        uiNotice.SetActive(false);
    }
}
