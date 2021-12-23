using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public float maxHp = 100;
    public float curHp = 100;
    public bool isPlayer = false;
    public Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
            hpText.text = "Health: " + curHp.ToString("N1") + " / " + maxHp.ToString("N1");
    }

    public void ChangeHp(float change)
    {
        //Note: if change < 0 then that means curHp should increase

        if (curHp > 0)
        {
            curHp -= change;
            if (isPlayer)
                hpText.text = "Health: " + curHp.ToString("N1") + " / " + maxHp.ToString("N1");
            print(curHp);
        }
        if (curHp <= 0)
        {
            if (isPlayer)
            {
                print("Fatality");
                SceneManager.LoadScene("Menu Screen");
            }
            else
                print("Enemy defeated");
            Destroy(gameObject);
        }
    }
}
