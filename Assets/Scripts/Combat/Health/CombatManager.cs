using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public int maxHp = 100;
    public int curHp = 100;
    public Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = "Health: " + curHp + " / " + maxHp;
    }

    public void ChangeHp(int change)
    {
        if (curHp > 0)
            curHp -= change;
        if (curHp <= 0)
            print("Fatality");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Danger"))
            ChangeHp(20);
    }
}
