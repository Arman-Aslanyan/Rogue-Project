using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Text startHpText;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeHp(int change, DamageListener source)
    {
        //Note: if change < 0 then that means curHp should increase

        if (source.curHp > 0)
        {
            source.curHp -= change;
        }
        
      /* Old code
        if (curHp > 0)
        {
            startHpText.text = "Health: " + curHp.ToString() + "/ " + maxHp.ToString();
        }
        else
        {
            //send to game over scene
            SceneManager.LoadScene("Game Over");
        }*/
    }
}