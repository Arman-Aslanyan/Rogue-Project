using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnParticle : MonoBehaviour
{

    public float despawnTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, despawnTime);
    }
}
