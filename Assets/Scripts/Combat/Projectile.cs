using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    float moveSpeed = 7f;

    Rigidbody2D rb;

    PlayerController3Dim target;
    Vector2 moveDirection;

    public ParticleSystem hitParticle;

    public string source;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerController3Dim>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        if (rb.velocity == Vector2.zero)
        {
            Destroy(gameObject);
            CreateHitParticle();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != source)
        {
            Debug.Log("Player had a nut thrown at them!");
            Destroy(gameObject);
            CreateHitParticle();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

    void CreateHitParticle()
    {
        ParticleSystem particle = Instantiate(hitParticle, transform.position, transform.rotation);
    }
}
