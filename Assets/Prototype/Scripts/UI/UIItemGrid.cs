using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
// TODO: use this class as a base for all slotted UI display for item lists
[RequireComponent(typeof(GridLayoutGroup))]
public class UIItemGrid : MonoBehaviour {

    RectTransform rectTransform;
    GridLayoutGroup gridLayoutGroup;
    public GameObject uiItemSlotPrefab;
    private float slotSize;
    public int maxColumns;
    public int maxRows;
    public List<UISlot> slotHandles;
    protected int numSlots;

    // Requirements: Manually set the panel position in the inspector before using
    void Awake() {
        rectTransform = GetComponent<RectTransform>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
 
    }

	public virtual void Start () {
        slotSize = rectTransform.sizeDelta.x / maxColumns; // using width as base
        gridLayoutGroup.cellSize = new Vector2(slotSize, slotSize);
        SetNumSlots(maxRows * maxColumns);
    }

    public void SetNumSlots(int amount) {
        rectTransform.sizeDelta = new Vector2((int)(slotSize * maxColumns),
                                              (int)(slotSize * maxRows));
        if (numSlots < amount) {
            for (int i = numSlots; i < amount; ++i) {
                GameObject tmp = Instantiate(uiItemSlotPrefab, transform) as GameObject;
                UISlot newSlot = tmp.GetComponent<UISlot>();
                slotHandles.Add(newSlot);
            }
        } else if (numSlots > amount) {
            slotHandles.RemoveRange(0, amount - numSlots);
        }
    }

    // Untested
    public void Resize(float width, float height) {
        rectTransform.sizeDelta = new Vector2(width, height);
        float newSize = width / maxRows;
        foreach (UISlot slot in slotHandles) {
            slotSize = newSize;
            slot.SetSize(newSize);
        }
    }

    // Untested
    private int GetGridIndex(int x, int y) {
        return maxRows / y + maxColumns % x;
    }

    public UISlot FindEmptySlot() {
        foreach(UISlot slot in slotHandles) {
            if (slot.IsEmpty) {
                return slot;
            }
        }
        return null;
    }
}
