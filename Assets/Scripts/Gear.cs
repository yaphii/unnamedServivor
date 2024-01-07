using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
	/*장비 타입과 수치 */
	public ItemData.ItemType type;
	public float rate;

	public void Init(ItemData data)
	{
		//Basic set
		name = $"Gear {data.itemId}";
		transform.parent = GameManager.instance.player.transform;
		transform.localPosition = Vector3.zero;
		//Property set
		type = data.itemType;
		rate = data.damages[0];
		ApplyGear();//기어가 처음 생성될때 플레이어가 가진 모든 무기에 기어에 대한 기능을 다 적용시킨다 
	}

	public void LevelUp(float rate)
	{
		this.rate = rate;
		ApplyGear();//장비가 새롭게 추가되었거나 레벨업 할때 로직 적용 함수를 호	
	}

	//타입에 따라 로직을 적용시켜주는 함수 
	public void ApplyGear()
	{   /*
	 	 * 1. 웨폰이 새로 생성되었을때 
	 	 * 2. 웨폰이 업그레이드 되었을때 
	 	 * 3. 기어 자체가 새로 생겼을때 
	 	 * 4. 기어 자체에서 레벨업이 되었을때 
	 	 * ApplyGear()를 호출한다 
	 	 */
		switch (type)
		{
			case ItemData.ItemType.Groove:
				RateUp();
				break;
			case ItemData.ItemType.Shoe:
				SpeedUp();
				break;
			default:
				break;
		}
	}
	//장갑의 기능인 연사력을 올리는 함/
	void RateUp()
	{
		//플레이어가 가지고있는 모든 무기
		Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();
		foreach (Weapon weapon in weapons)
		{
			switch (weapon.id)
			{
				case 0:
					float speed = 150*Character.WeaponSpeed;
					weapon.speed =speed + (speed * rate);
					break;
				default://원거리 무 0.5f * 0.25f(0.125초 후 총알 발사 )
					speed = 0.5f*Character.WeaponRate;
					weapon.speed = speed * (1f - rate);
					break;
			}
		}
	}

	void SpeedUp()
	{
		float speed = 3 * Character.Speed;
		GameManager.instance.player.speed = speed + speed * rate;

	}
}