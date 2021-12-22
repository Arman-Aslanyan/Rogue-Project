using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvManager : MonoBehaviour
{
    public Canvas canvas;
    public List<Image> InvSlots = new List<Image>();
    public Image invItemImg;
    public Text invItemDesc;
    public Text invItemName;

    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.GetChild(0).GetComponent<Canvas>();
        canvas.enabled = false;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("InvSlot"))
            InvSlots.Add(obj.GetComponent<Image>());
        print(InvSlots.Count);
        invItemImg = canvas.transform.GetChild(1).GetComponent<Image>();
        invItemDesc = canvas.transform.GetChild(2).GetComponent<Text>();
        invItemName = canvas.transform.GetChild(3).GetComponent<Text>();
    }

    public void UIEnabledSwitch(bool isEnabled)
    {
        canvas.enabled = !isEnabled;
        if (canvas.enabled == false)
        {
            InvManager Inv = GameObject.FindObjectOfType<InvManager>();
            Inv.invItemImg.sprite = null;
            Inv.invItemImg.color = new Color(255, 255, 255, 0);
            Inv.invItemName.text = null;
            Inv.invItemName.color = new Color(255, 255, 255, 0);
            Inv.invItemDesc.text = null;
            Inv.invItemDesc.color = new Color(255, 255, 255, 0);
        }
    }

    public bool CanStoreItem()
    {
        int occupied = 0;
        foreach (Image img in InvSlots)
        {
            if (img.sprite != null)
                occupied++;
        }
        return !(occupied == InvSlots.Count);
    }

    public int GetOpenSlot(bool canStore)
    {
        //-1 in case of unavailable slots
        int slotIndex = -1;
        if (canStore)
        {
            for (int i = 0; i < InvSlots.Count; i++)
            {
                if (InvSlots[i].sprite == null)
                {
                    slotIndex = i;
                    i = InvSlots.Count + 1;
                }
            }
        }
        return slotIndex;
    }

    public void ChangeSlotSprite(SpriteRenderer spr, int index)
    {
        InvSlots[index].sprite = spr.sprite;
        InvSlots[index].color = spr.color + new Color(0, 0, 0, 255);
    }

    public void GiveSlotItemPrefab(int index, GameObject toAssign)
    {
        InvSlots[index].transform.parent.GetComponent<SlotScript>().prefab = toAssign;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            UIEnabledSwitch(canvas.enabled);
    }
}
