using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeToDestroy(deathTimer));
    }

    public IEnumerator TimeToDestroy(float wait)
    {
        yield return new WaitForSeconds(wait);
        Destroy(gameObject);
    }
}
