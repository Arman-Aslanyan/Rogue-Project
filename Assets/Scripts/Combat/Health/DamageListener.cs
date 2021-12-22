using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageListener : MonoBehaviour
{
    public int maxHp = 100;
    public int curHp = 100;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Danger"))
            FindObjectOfType<HealthManager>().ChangeHp(20, this);
    }
}
