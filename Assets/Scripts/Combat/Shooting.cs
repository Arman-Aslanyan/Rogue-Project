using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    public float fireRate;
    public float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            GameObject clone;
            clone = Instantiate(projectile, transform.position, Quaternion.identity);
            clone.GetComponent<Projectile>().source = gameObject.name;
            nextFire = Time.time + fireRate;
        }
    }
}
