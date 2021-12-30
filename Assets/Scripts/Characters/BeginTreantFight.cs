using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginTreantFight : MonoBehaviour
{
    private GameObject fakeTreant;
    public GameObject realTreant;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        fakeTreant = gameObject;
        anim = GetComponent<Animator>();
        anim.enabled = false;
        realTreant.SetActive(false);
    }

    public void BeginTheChaos(bool canStart)
    {
        if (canStart)
        {
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
        fakeTreant.SetActive(false);
        realTreant.SetActive(true);
    }
}
