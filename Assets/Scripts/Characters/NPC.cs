using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public bool isPlayer;
    public bool isAlsoPlayer;
    private bool testing = false;
    private bool dumbBad = false;
    private bool runOnce = true;
    private bool testRun = true;
    private Transform AAAAA;
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
    }

    public void OnMouseUp()
    {
        if (gameObject.CompareTag("Sir Orange"))
            FindObjectOfType<PlayerController3Dim>().spokeToKnight = true;
        speechBox.text = "";
        if (testing)
        {
            dumbBad = false;
            StopCoroutine(IBetBlakeWillTestThis());
        }
        if (!hasClicked && index < dialogue.Length && !isPlayer)
        {
            print("runs");
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
            foreach (char character in str.ToCharArray())
            {
                speechBox.text += character;
                yield return new WaitForSeconds(typingSpeed);
            }
            dumbBad = true;
            StartCoroutine(IBetBlakeWillTestThis());
            isSpeaking = false;
            //For implementing NPC with player interactions
            //Then start here by checking an array that contains the indexes for each line that
            //requires player input after that line is mentioned then do the rest afterward
        }
    }

    public IEnumerator IBetBlakeWillTestThis()
    {
        print("E");
        testing = true;
        yield return new WaitForSeconds(disableTimer);
        if (dumbBad)
        {
            if (isPlayer && AAAAA != null)
                StartCoroutine(pain(AAAAA));
            else
            {
                boxSprite.enabled = false;
                speechBox.text = "";
                speechBox.enabled = false;
                hasClicked = false;
                index = 0;
                if (speechBox.fontStyle != FontStyles.Normal && !FindObjectOfType<PlayerController3Dim>().spokeToKnight)
                    speechBox.fontStyle = FontStyles.Normal;
            }
        }
        dumbBad = false;
        print(testing);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WHEEZE"))
        {
            if (isPlayer && !GetComponent<PlayerController3Dim>().spokeToKnight)
            {
                GetComponent<PlayerController3Dim>().canMove = false;
                GameObject.FindGameObjectWithTag("Sir Orange");
                isPlayer = false;
                OnMouseUp();
                isPlayer = true;
                if (runOnce)
                {
                    print(testing);
                    runOnce = false;
                    if (testRun)
                    {
                        testRun = false;
                        other.transform.position = new Vector3(other.transform.position.x, 5, 1);
                    }
                    dumbBad = false;
                    AAAAA = other.transform;
                }
            }
        }
    }

    public IEnumerator pain(Transform obj)
    {
        yield return new WaitForSeconds(0.5f);
        obj.position = new Vector3(obj.transform.position.x, 7.5f, 1);
        //dialogue[0].Insert(0, "/i ");
        AAAAA = null;
        yield return new WaitForSeconds(1);
        runOnce = true;
        testRun = true;
        GetComponent<PlayerController3Dim>().canMove = true;
    }
}