using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDamage : MonoBehaviour
{
    //This script is attached to gameobjects w/ colliders that have been instantiated from weapon usage and dmg's first entity hit if any

    public float dmgToDeal;
    public string sourceName;
    private bool ignore1stRun = true;
    private float curTime;
    [Tooltip("Used for body damage over time")]
    public float toDmgTime = 2.5f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!ignore1stRun)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                HealthManager hpMan = other.gameObject.GetComponent<HealthManager>();
                hpMan.ChangeHp(dmgToDeal);
            }
        }
        else
            ignore1stRun = false;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            curTime += Time.deltaTime;
            if (curTime >= toDmgTime)
            {
                HealthManager hpMan = other.gameObject.GetComponent<HealthManager>();
                hpMan.ChangeHp(dmgToDeal);
                curTime = 0;
                print("Took Damage");
            }
        }
    }
}
