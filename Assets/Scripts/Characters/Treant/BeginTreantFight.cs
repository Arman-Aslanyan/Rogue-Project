using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginTreantFight : MonoBehaviour
{
    private GameObject fakeTreant;
    public GameObject realTreant;
    private Animator anim;
    private Animator orngAnim;

    // Start is called before the first frame update
    void Start()
    {
        fakeTreant = gameObject;
        anim = GetComponent<Animator>();
        anim.enabled = false;
        realTreant.SetActive(false);
        orngAnim = GameObject.FindGameObjectWithTag("Sir Orange").GetComponent<Animator>();
        orngAnim.enabled = false;
    }

    public void BeginTheChaos(bool canStart)
    {
        if (canStart)
        {
            FindObjectOfType<PlayerController3Dim>().DisableKeyPress();
            anim.enabled = true;
            StartCoroutine(wait());
        }
    }

    public IEnumerator wait()
    {
        NPC npc = GetComponent<NPC>();
        npc.shouldClick = true;
        npc.OnMouseUp();
        npc.shouldClick = false;
        yield return new WaitForSeconds(6);
        npc.boxSprite.enabled = false;
        npc.speechBox.text = "";
        npc.speechBox.enabled = false;
        Transform orange = GameObject.FindGameObjectWithTag("Sir Orange").transform;
        orngAnim.enabled = true;
        yield return new WaitForSeconds(3);
        orngAnim.enabled = false;
        npc.dialogue[1] = "OH HO HO! Well thats your problem seeya he he he HA!!!!";
        StartCoroutine(npcSpeak(npc.dialogue[1], npc));
        yield return new WaitForSeconds(5);
        orange.position = new Vector3(-1.5f, 5.3f, 0);
        Destroy(orange);
        fakeTreant.SetActive(false);
        realTreant.SetActive(true);
    }

    public IEnumerator npcSpeak(string str, NPC npc)
    {
        npc.boxSprite.enabled = true;
        //Auto-Type
        foreach (char character in str.ToCharArray())
        {
            npc.speechBox.text += character;
            yield return new WaitForSeconds(npc.typingSpeed);
        }
        StartCoroutine(IBetBlakeWillTestThis(npc));
    }

    public IEnumerator IBetBlakeWillTestThis(NPC npc)
    {
        yield return new WaitForSeconds(1);
        npc.boxSprite.enabled = false;
        npc.speechBox.text = "";
        npc.speechBox.enabled = false;
    }
}
