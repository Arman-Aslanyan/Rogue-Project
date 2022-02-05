using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginTreantFight : MonoBehaviour
{
    private GameObject fakeTreant;
    public GameObject realTreant;
    private Animator anim;
    private Animator orngAnim;
    public GameObject itemPrefab;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fakeTreant = gameObject;
        anim = GetComponent<Animator>();
        anim.enabled = false;
        realTreant.SetActive(false);
        orngAnim = GameObject.FindGameObjectWithTag("Sir Orange").GetComponent<Animator>();
        orngAnim.enabled = false;
    }

    private void Update()
    {
        /*float dist = Vector2.Distance(transform.position, player.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && dist <= 2.5f && FindObjectOfType<PlayerController3Dim>().spokeToKnight)
            BeginTheChaos();*/
    }

    private void OnMouseUp()
    {
        BeginTheChaos();
    }

    public void BeginTheChaos()
    {
        FindObjectOfType<PlayerController3Dim>().DisableKeyPress();
        anim.enabled = true;
        StartCoroutine(wait());
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        NPC npc = GetComponent<NPC>();
        npc.shouldClick = true;
        npc.speechBox.enabled = true;
        StartCoroutine(npcSpeak(npc.dialogue[0], npc));
        npc.shouldClick = false;
        yield return new WaitForSeconds(3);
        Transform orange = GameObject.FindGameObjectWithTag("Sir Orange").transform;
        orngAnim.enabled = true;
        yield return new WaitForSeconds(3);
        orngAnim.enabled = false;
        npc.speechBox.text = "";
        //David... it's not what it looks like. Trust me.. nothing janky going on here
        StartCoroutine(npcSpeak(transform.GetChild(0).GetComponent<NPC>().dialogue[0], transform.GetChild(0).GetComponent<NPC>()));
        yield return new WaitForSeconds(5);
        npc.boxSprite.enabled = false;
        npc.speechBox.text = "";
        npc.speechBox.enabled = false;
        orange.position = new Vector3(-1.5f, 5.3f, 0);
        Destroy(orange.gameObject);
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
    }
}
