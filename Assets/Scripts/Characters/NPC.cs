using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NPC : MonoBehaviour
{
    public bool isPlayer;
    public bool isAlsoPlayer;
    public string[] dialogue;
    public TMP_Text speechBox;
    public Image boxSprite;
    private int index = 0;
    //Auto-Type speed of NPC
    [Tooltip("Is measured in seconds")]
    public float typingSpeed = 0.02f;
    private bool hasClicked = false;
    private bool isSpeaking = false;
    public float disableTimer = 10;

    // Start is called before the first frame update
    void Start()
    {
        speechBox.text = "";
        //Player speaks to self
        if (isPlayer)
        {
            isPlayer = false;
            OnMouseUp();
            isPlayer = true;
        }
    }

    public void OnMouseUp()
    {
        speechBox.text = "";
        StopCoroutine(IBetBlakeWillTestThis());
        if (!hasClicked && index < dialogue.Length && !isPlayer)
        {
            hasClicked = true;
            boxSprite.enabled = true;
            speechBox.enabled = true;
            print(dialogue[index]);
            if (dialogue[0].Substring(0, 2) == "/i")
            {
                speechBox.fontStyle = FontStyles.Italic;
                dialogue[0] = dialogue[0].Substring(2);
            }
            for (int i = 0; i < dialogue[index].Length; i++)
            {
                StartCoroutine(NPCDialogueTimer(dialogue[index]));
            }
            index++;
            hasClicked = false;
            if (isAlsoPlayer)
            {
                StopCoroutine(IBetBlakeWillTestThis());
                OnMouseUp();
            }
        }
        else
        {
            boxSprite.enabled = false;
            speechBox.text = "";
            speechBox.enabled = false;
            hasClicked = true;
            index = 0;
        }
    }

    public IEnumerator NPCDialogueTimer(string str)
    {
        if (!isSpeaking)
        {
            isSpeaking = true;
            boxSprite.enabled = true;
            //Auto-Type
            StartCoroutine(IBetBlakeWillTestThis());
            foreach (char character in str.ToCharArray())
            {
                speechBox.text += character;
                yield return new WaitForSeconds(typingSpeed);
            }
            isSpeaking = false;
            //For implementing NPC with player interactions
            //Then start here by checking an array that contains the indexes for each line that
            //requires player input after that line is mentioned then do the rest afterward
        }
    }

    public IEnumerator IBetBlakeWillTestThis()
    {
        yield return new WaitForSeconds(disableTimer);
        boxSprite.enabled = false;
        speechBox.text = "";
        speechBox.enabled = false;
        hasClicked = false;
        index = 0;
        if (speechBox.fontStyle != FontStyles.Normal)
            speechBox.fontStyle = FontStyles.Normal;
    }
}