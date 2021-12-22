using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDamage : MonoBehaviour
{
    //This script is attached to gameobjects w/ colliders that have been instantiated from weapon usage and dmg's first entity hit if any

    public float dmgToDeal;
    public string sourceName;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Object") && other.gameObject.name != sourceName)
        {
            HealthManager hpMan = other.gameObject.GetComponent<HealthManager>();
            hpMan.ChangeHp(dmgToDeal);
        }
        Destroy(gameObject);
    }
}
