using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	public ItemData data;
	public int level;
	public Weapon weapon;
	public Gear gear;

	Image icon;
	Text textLevel;

	private void Awake()	{		//icon 초기화 		icon = GetComponentsInChildren<Image>()[1];		icon.sprite = data.itemIcon;		Text[] texts = GetComponentsInChildren<Text>();		textLevel = texts[0];							}

	private void LateUpdate()	{		textLevel.text = "Lv." + (level + 1);	}

	public void OnClick()	{
		switch (data.itemType)		{			case ItemData.ItemType.Melee:			case ItemData.ItemType.Range:				if(level == 0)//level 0 일때 새롭게 gameobject를 생성한다 				{					GameObject newWeapon = new GameObject();					weapon = newWeapon.AddComponent<Weapon>();//AddComponent : GameObjec에 <>컴포넌트를 추가					weapon.Init(data);				}				else//처음이후의 레벨업은 데미지와 횟수를 계산한다 				{					float nextDamage = data.baseDamage;					int nextCount = 0;					nextDamage += data.baseDamage * data.damages[level];					nextCount += data.counts[level];					weapon.LevelUp(nextDamage, nextCount);				}				break;			case ItemData.ItemType.Groove:			case ItemData.ItemType.Shoe:				if (level == 0)				{	//무기 로직과 마찬가지로 최초 레벨업은 게임오브젝트 생성로직을 작ㅜ					GameObject newGear = new GameObject();					gear = newGear.AddComponent<Gear>();//AddComponent : GameObjec에 <>컴포넌트를 추가					gear.Init(data);				}				else				{					float nextRate = data.damages[level];					gear.LevelUp(nextRate);				}				break;			case ItemData.ItemType.Heal:				GameManager.instance.health = GameManager.instance.maxHealth;				break;			default:				break;		}		level++;		//레벨이 최대가 되어 더이상 올라가지 않도록 처리		if(level == data.damages.Length)		{			GetComponent<Button>().interactable = false; 		}	}
}
