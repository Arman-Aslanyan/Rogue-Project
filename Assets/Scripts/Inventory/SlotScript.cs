using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    private Image thisImg;
    public string itemName;
    public Color nameColor;
    public string itemDesc;
    public Color descColor;

    public GameObject prefab;
    private bool assign = true;

    // Start is called before the first frame update
    void Start()
    {
        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image img in images)
        {
            if (img.gameObject.name == "Img")
                thisImg = img;
        }
    }

    private void OnMouseUp()
    {
        if (thisImg.sprite != null)
        {
            InvManager Inv = GameObject.FindObjectOfType<InvManager>();
            if (Inv.canvas.enabled)
            {
                Inv.invItemImg.sprite = thisImg.sprite;
                Inv.invItemImg.color = thisImg.color;
                Inv.invItemName.text = itemName;
                Inv.invItemName.color = nameColor;
                Inv.invItemDesc.text = itemDesc;
                Inv.invItemDesc.color = descColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (prefab != null && assign)
        {
            assign = false;
            ItemData item = prefab.GetComponent<ItemData>();
            itemName = item.itemName;
            nameColor = item.nameColor;
            itemDesc = item.itemDesc;
            descColor = item.descColor;
        }
    }
}
