using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LevelUp : MonoBehaviour
{

    RectTransform rect;
    
    // Start is called before the first frame update
    private void Awake() {
        rect = GetComponent<RectTransform>();
    }

    public void Show(){
        rect.localScale = Vector3.one;
    }
    public void Hide(){
        rect.localScale = Vector3.zero;

    }
}

