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

	private void Awake()

	private void LateUpdate()

	public void OnClick()
		switch (data.itemType)
}