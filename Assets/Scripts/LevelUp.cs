using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LevelUp : MonoBehaviour
{

    RectTransform rect;
    Item [] items;
    // Start is called before the first frame update
    private void Awake() {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
    }

    public void Show(){
        rect.localScale = Vector3.one;
        GameManager.instance.Stop();
    }
    public void Hide(){
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
    }

    public void Select(int index){
        items[index].OnClick();
    }


}

