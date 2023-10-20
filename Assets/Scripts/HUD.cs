using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //다루게 될 enum을 미리 선언 
    public enum InfoType {
        //경험치  레벨  킬  타임  헬
        Exp,
        Level,
        Kill,
        Time,
        Health
    }    public InfoType type;
    Text myText;
    Slider mySlider;	private void Awake()	{        myText = GetComponent<Text>();		mySlider = GetComponent<Slider>();							}	// Start is called before the first frame update														void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }	private void LateUpdate()	{        switch (type)        {            case InfoType.Exp:                float curExp = GameManager.instance.exp;				float maxExp = GameManager.instance.nextExp[GameManager.instance.level];                mySlider.value = curExp / maxExp;				break;            case InfoType.Health:                break;            case InfoType.Level:                break;            case InfoType.Kill:                break;            case InfoType.Time:                break;            default:                break;        }         }
}
