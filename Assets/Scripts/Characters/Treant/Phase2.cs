using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        HealthManager hpMan = GetComponent<HealthManager>();
        if (hpMan.curHp <= 50)
        {
            //Treant go BBRRRRRR
            Shooting shut = GetComponent<Shooting>();
            shut.projectile.transform.localScale = new Vector3(2, 2, 1);
            shut.baseDmg = 10;
            shut.fireRate = 2;
            shut.travelRate = 14;
        }
    }
}
