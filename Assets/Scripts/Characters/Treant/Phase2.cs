using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2 : MonoBehaviour
{
    public Animator animator;
    bool isTransformGoneOff = false;
    public Rigidbody2D rb;
    public GameObject acornBig;
    Shooting shoot;


    private void Start()
    {
        shoot = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthManager hpMan = GetComponent<HealthManager>();


        if (hpMan.curHp <= 50)
        {
            //Treant go BBRRRRRR
            shoot.projectile = acornBig;
            shoot.baseDmg = 10;
            shoot.fireRate = 2;
            shoot.travelRate = 14;
            if (!isTransformGoneOff)
            {
                animator.SetBool("isTransforming", true);
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                shoot.enabled = false;
                StartCoroutine(wait());
            }
        }
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("isTransforming", false);
        shoot.enabled = true;
        isTransformGoneOff = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}
