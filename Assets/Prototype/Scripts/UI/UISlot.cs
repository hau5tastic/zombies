using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Base Slot for items and skills
[RequireComponent(typeof(LayoutElement))]
public class UISlot : MonoBehaviour {

    Image image;
    Button button;
    LayoutElement layoutElement;
    private Sprite emptySprite;
    public bool IsEmpty;
    int index;

	void Awake() {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        layoutElement = GetComponent<LayoutElement>();
        emptySprite = image.sprite;
        IsEmpty = true;
    }

    public void ClearSlot() {
        image.sprite = emptySprite;
        IsEmpty = true;
        enabled = false;
    }

    public void SetItem(Item item) {
        image.sprite = item.GetSprite();
        IsEmpty = false;
    }

    public void SetColor(Color newColor) {
        image.color = newColor;
    }

    // Cellsize must be disabled in parent gridLayout
    public void SetSize(float size) {
        layoutElement.minWidth = size;
        layoutElement.minHeight = size;
        layoutElement.preferredWidth = size;
        layoutElement.preferredHeight = size;
    }
}
