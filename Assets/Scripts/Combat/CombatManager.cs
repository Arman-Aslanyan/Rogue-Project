using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public float dmgDealt;

    public void OnTriggerEnter2D(Collider2D other)
    {
        HealthManager hpMan = other.GetComponent<HealthManager>();
        hpMan.ChangeHp(dmgDealt);
    }
}
