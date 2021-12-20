using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldUIManager : MonoBehaviour
{
    private Canvas canvas;
    public List<Image> InvSlots = new List<Image>();
    public bool isSorted = false;
    public Text itemDescText;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        //List<Image> images = new List<Image>();
        //Gets and Stores all existing Images
        //Try to get InvSlots only have values of ACTUAL InvSLots. NOT InvisSlot!!
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("InvSlot"))
            InvSlots.Add(obj.GetComponent<Image>());
        print(InvSlots.Count);
        itemDescText.enabled = false;
    }

    //Self-Explanatory
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

    //Self-Explanatory
    public int GetOpenSlot(bool store)
    {
        //-1 in case of no slot available
        int slot = -1;
        if (store)
        {
            for (int i = 0; i < InvSlots.Count; i++)
            {
                if (InvSlots[i].sprite == null)
                {
                    slot = i;
                    i = InvSlots.Count + 1;
                }
            }
        }
        return slot;
    }

    //Self-Explanatory
    public void ChangeSlotSprite(SpriteRenderer spr, int index)
    {
        InvSlots[index].sprite = spr.sprite;
        InvSlots[index].color = spr.color;
    }

    //Self-Explanatory
    public void UIEnabledSwitch(bool isEnabled)
    {
        canvas.enabled = !isEnabled;
    }

    public void GiveSlotItemPrefab(int index, GameObject toAssign)
    {
        InvSlots[index].transform.parent.GetComponent<OldSlotScript>().prefab = toAssign;
        //print("prefab assigned");
    }

    //Runs On Button Click
    public void SortInventory()
    {
        //Multi-Dimensioanl List (2D)
        //Hold all types of Items and all items of each type held
        List<List<string>> multiDim = new List<List<string>>(); //Add sub-list --> multiDim.Add(new List<string>());
                                                               //Add element to sub-list --> multiDim[index].Add(/*string here*/);
                                                              //Access sub-list element --> multiDim[index][index2]
        //Get all Slots and each Item within
        List<OldSlotScript> slots = new List<OldSlotScript>();
        List<string> itemNames = new List<string>();
        for (int i = 0; i < InvSlots.Count - 1; i++)
        {
            if (InvSlots[i].sprite != null)
                slots.Add(InvSlots[i].GetComponentInParent<OldSlotScript>());
            //print(slots[i].transform.name);
        }
        foreach (OldSlotScript instance in slots)
        {
            //items[i] = InvSlots[i];
            itemNames.Add(instance.itemName);
        }
        //Filter all items to get rid of duplicates
        List<string> typeNames = new List<string>();
        foreach (string str in itemNames)
            typeNames.Add(str);
        for (int i = 0; i < itemNames.Count; i++)
        {
            int count = 0;
            for (int j = 0; j < typeNames.Count; j++)
            {
                if (itemNames[i] == typeNames[j])
                    ++count;
                if (count > 1)
                {
                    typeNames.RemoveAt(j);
                    --count;
                }
            }
        }
        typeNames.Sort();
        print("-----------------");
        for (int i = 0; i < typeNames.Count; i++)
            print(" | " + typeNames[i] + " " + i + " | ");
        for (int i = 0; i < typeNames.Count; i++)
        {
            multiDim.Add(new List<string>());
            print(multiDim.Count);
            //Add element to sub-list (sub-list holds every instance of one item)
            for (int j = 0; j < itemNames.Count; j++)
            {
                if (itemNames[j] == typeNames[i])
                    multiDim[i].Add(itemNames[j]);
            }
        }
        for (int i = 0; i < multiDim.Count; i++)
        {
            foreach (string str in multiDim[i])
            {
                print(" | " + str + " | ");
            }
        }
        if (!isSorted)
        {
            //Index to set InvSlot siblingIndex
            int sibIndex = 0;
            //Used for Un-Sorting Inventory
            List<int> sibIndexVal = new List<int>();
            for (int i = 0; i < multiDim.Count; i++)
            {
                for (int j = 0; j < slots.Count; j++)
                {
                    if (multiDim[i][0] == slots[j].itemName)
                    {
                        slots[j].transform.SetSiblingIndex(sibIndex);
                        print(slots[j].transform.name);
                        sibIndexVal.Add(sibIndex);
                        sibIndex++;
                    }
                }
            }
            //Inventory is now sorted
            isSorted = true;
            //Reset in case of 2nd Function usage
            sibIndex = 0;

            //Change Sort button text to "Un-Sort"
            Text sortText = GetComponentInChildren<Button>().GetComponentInChildren<Text>();
            sortText.text = "Un-Sort";
        }
        else
            UnSortInventory(slots);
    }

    public void UnSortInventory(List<OldSlotScript> slots)
    {
        print("runs");
        foreach (OldSlotScript slot in slots)
        {
            print("Changed");
            slot.transform.SetSiblingIndex(slot.OrigSibIndex);
        }

        //Change Sort button text to "Sort"
        Text sortText = GetComponentInChildren<Button>().GetComponentInChildren<Text>();
        sortText.text = "Sort";

        //Reset | Allows user to sort once more
        isSorted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UIEnabledSwitch(canvas.enabled);
        }
    }
}
