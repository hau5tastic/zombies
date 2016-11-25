using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIQuickslot : MonoBehaviour {

    Image image;
    Button button;
    int index;
	
    void Awake() {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    public void SetSprite(Sprite sprite) {
        image.sprite = sprite;
    }

    public void SetIndex(int index) {
        button.GetComponentInChildren<Text>().text = index.ToString();
    }

}
