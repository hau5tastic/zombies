using UnityEngine;
using System.Collections;

public class UITradeslotPanel : UIItemGrid {

    private int limit;

    public override void Start() {
        base.Start();
        limit = maxRows * maxColumns;
    }

	public void AddItem(Item item) {
        FindEmptySlot().SetItem(item);
    }
}
