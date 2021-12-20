using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldCapsuleScript : MonoBehaviour
{
    public GameObject itemPrefab;

    private void OnMouseUp()
    {
        OldUIManager Inv = FindObjectOfType<OldUIManager>();
        SpriteRenderer spr = itemPrefab.GetComponent<SpriteRenderer>();
        int index = Inv.GetOpenSlot(Inv.CanStoreItem());
        if (index != -1)
        {
            Inv.ChangeSlotSprite(spr, index);
            Inv.GiveSlotItemPrefab(index, itemPrefab);
            Inv.itemDescText.enabled = false;
        }
        else
            print("Inventory is Full!!");
    }
}
