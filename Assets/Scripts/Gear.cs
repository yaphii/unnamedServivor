using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
	/*장비 타입과 수치 */
	public ItemData.ItemType type;
	public float rate;

	public void Init(ItemData data)

	public void LevelUp(float rate)
		this.rate = rate;

	//타입에 따라 로직을 적용시켜주는 함수 
	public void ApplyGear()
	//장갑의 기능인 연사력을 올리는 함/
	void RateUp()

	void SpeedUp()
		float speed = 3;
}