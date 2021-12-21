using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    private Image thisImg;
    public GameObject textBox;
    public Text text;
    public string itemName;
    public Color nameColor;
    public string itemDesc;
    public Color descColor;
    private Vector2 mousePos;
    private Canvas parentCanvas;
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

        text = textBox.GetComponent<Text>();
        parentCanvas = GetComponentInParent<Canvas>();
    }

    private void OnMouseUp()
    {
        if (thisImg.sprite != null)
        {
            thisImg.sprite = null;
            thisImg.color = new Color(255, 255, 255, 0);
            //Reset slot variables
            prefab = null;
            assign = true;
            itemName = null;
            nameColor = new Color(255, 255, 255, 0);
            itemDesc = null;
            descColor = new Color(255, 255, 255, 0);
            //Afterwards, reset item text as well
            OnMouseExit();
        }
    }

    private void OnMouseEnter()
    {
        bool enabled = TextEnabler(true);
        TextChange(enabled);
    }

    private void OnMouseOver()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform, Input.mousePosition,
            parentCanvas.worldCamera,
            out mousePos);
        textBox.transform.position = parentCanvas.transform.TransformPoint(mousePos);
    }

    private void OnMouseExit()
    {
        TextChange(false);
        TextEnabler(false);
    }

    public void TextChange(bool enabled)
    {
        if (enabled)
            text.text = itemName + "\n" + itemDesc;
        else
            text.text = " ";
    }

    public bool TextEnabler(bool literal)
    {
        text.enabled = literal;
        return text.enabled;
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
            TextChange(true);
        }
    }
}
