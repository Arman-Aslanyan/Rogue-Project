using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public float baseDmg;
    public float fireRate;
    public float nextFire;
    public float travelRate;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            GameObject clone;
            clone = Instantiate(projectile, transform.position, Quaternion.identity);
            Projectile Proj = clone.GetComponent<Projectile>();
            Proj.source = gameObject.name;
            Proj.moveSpeed = travelRate;
            Proj.dmgToDeal = baseDmg;
            nextFire = Time.time + fireRate;
        }
    }
}
