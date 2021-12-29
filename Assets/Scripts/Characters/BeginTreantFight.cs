using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginTreantFight : MonoBehaviour
{
    public GameObject fakeTreant;
    private GameObject realTreant;

    // Start is called before the first frame update
    void Start()
    {
        realTreant = gameObject;
        realTreant.SetActive(false);
    }

    public void BeginTheChaos(bool canStart)
    {
        if (canStart)
        {
            fakeTreant.SetActive(false);
            realTreant.SetActive(true);
        }
    }
}
