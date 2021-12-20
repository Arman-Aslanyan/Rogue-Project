using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public string AtomicInteger = "1";
    public int maxHp = 100;
    public int curHp = 100;
    public Text startHpText;

    // Start is called before the first frame update
    void Start()
    {
        startHpText.text = "Health: " + curHp.ToString() + "/ " + maxHp.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHp()
    {

        if (curHp > 0)
        {
            startHpText.text = "Health: " + curHp.ToString() + "/ " + maxHp.ToString();
        }
        else
        {
            //send to game over scene
            SceneManager.LoadScene("Game Over");
        }
    }
}