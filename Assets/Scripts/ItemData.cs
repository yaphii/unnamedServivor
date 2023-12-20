using System.Collections;
using System.Collections.Generic;
using UnityEngine;/* CreateAssetMenu : 커스텀 메뉴를 생성하는 속성  */[CreateAssetMenu(fileName ="Item", menuName ="Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{	//무기  기여아이템 일회용아이템 : 근접공격	//Melee : 칼이나 창을 써서 싸우든, 주먹을 겨루든 간에 '근접해서 싸우다'라는 뜻을 가진 단어    //근접공격 원거리공격 장갑 신발 음료	public enum ItemType { Melee, Range, Groove, Shoe, Heal }

    [Header("# Main Info")]//ㅇㅏㅇㅣㄷㅣ ㅇㅣㄹㅡㅁ ㅅㅗㄱㅅㅓㅇ ㅇㅓㅣㅏㄹㄴㅓㅣㅇ    public ItemType itemType; 	public int itemId;
    public string itemName;

    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;	//ㄹㅔ벨별로 상승하는 능력치    [Header("# Level Data")]	//0레벨 데미지    public float baseDamage;    //근접: 갯수     원거리: 관통      public int baseCount;    //레벨별 수치     public float[] damages;    public int[] counts;    [Header("# Weapon")]//특수한 무기
    //계속 쏘는 투사체 프리
    public GameObject projectile;
    public Sprite hand;//Hand
}
