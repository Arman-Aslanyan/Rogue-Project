using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldSlotScript : MonoBehaviour
{
    private Image thisImg;
    public GameObject textBox;
    public Text text;
    public string itemName;
    public Color nameColor;
    public string itemDesc;
    public Color descColor;
    public int OrigSibIndex;
    public int sibIndex;
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

    //Essentially deletes item from existence and opens of the slot once again
    private void OnMouseUp()
    {
        if (thisImg.sprite != null)
            thisImg.sprite = null;
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

    private void TextChange(bool enabled)
    {
        if (enabled)
        {
            /*GUIStyle style = new GUIStyle();
            style.richText = true;
            text.text = ("<color=nameColor>itemName</color> \n<color=descColor>itemDesc</color>");*/
            text.text = itemName + " \n" + itemDesc;
        }
        else
            text.text = " ";
    }

    public bool TextEnabler(bool literal)
    {
        text.enabled = literal;
        return text.enabled;
    }

    private void Update()
    {
        if (prefab != null && assign)
        {
            //print(prefab.name);
            assign = false;
            OldItemData item = prefab.GetComponent<OldItemData>();
            itemName = item.itemName;
            nameColor = item.nameColor;
            itemDesc = item.itemDesc;
            descColor = item.descColor;
            TextChange(true);
        }
    }
}
