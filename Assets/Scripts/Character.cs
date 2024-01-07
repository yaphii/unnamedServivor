using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
캐릭터의 특성을 관리함.
*/
public class Character : MonoBehaviour
{
    public static float Speed{//함수가 아닌 속성을 작성
        get { return GameManager.instance.playerId == 0 ? 1.1f : 1f; }
    }

    public static float WeaponSpeed{//무기의 발사속도
        get { return GameManager.instance.playerId == 1 ? 1.1f : 1f; }
    }

    public static float WeaponRate{//원거리 무기
        get { return GameManager.instance.playerId == 1 ? 0.9f : 1f; }
    }

    public static float Damage{
        get { return GameManager.instance.playerId == 2 ? 1.2f : 1f; }
    }

    public static int Count{
        get { return GameManager.instance.playerId == 3 ? 1 : 0; }
    }
}
