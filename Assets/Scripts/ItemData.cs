using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemData : ScriptableObject
{

    [Header("# Main Info")]//ㅇㅏㅇㅣㄷㅣ ㅇㅣㄹㅡㅁ ㅅㅗㄱㅅㅓㅇ ㅇㅓㅣㅏㄹㄴㅓㅣㅇ
    public string itemName;
    public string itemDesc;
    public Sprite itemIcon;
    //계속 쏘는 투사체 프리
    public GameObject projectile;
}