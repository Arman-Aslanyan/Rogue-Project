using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    //Script to be attached to all entities and have current held weapon/item stored for later use

    //Weapon/item equipped
    public ItemData obj;
    public Sprite EnemyWeaponSprite;
    public SpriteRenderer itemHeld;
    public Transform attackSummonPos;
    public int heldIndex = -1;
    public float attackSpeed = 100;
    [Tooltip("For example, sword swing object w/ collider that damages other entities upon contact")]
    public GameObject damager;
    public float baseDmg;
    private Vector2 mouseDir;
    public HealthManager hpMan;

    private void Start()
    {
        hpMan = GetComponent<HealthManager>();
        if (!hpMan.isPlayer)
            itemHeld.sprite = EnemyWeaponSprite;
    }

    private void Update()
    {
        //Error appears here | no idea why, it simply does
        if (hpMan.isPlayer)
        {
            mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDir = mouseDir - (Vector2)transform.position;
            itemHeld.transform.right = mouseDir;
            itemHeld.transform.Rotate(new Vector3(0, 0, -45));
        }
        else if (!hpMan.isPlayer)
        {
            //gameObject is an enemy.. Calculate weapon/item usage here
            //Essentially created the Enemy Controller (combat) here

            //To do later
        }
        if (hpMan.isPlayer && Input.GetMouseButtonUp(0) && itemHeld.sprite != null)
            UseEquipped(hpMan.isPlayer);
    }

    public void UseEquipped(bool isPlayer)
    {
        //Calculate combat dmg here
        GameObject clone;

        //Steps: 
        //Instantiate the projectile/dmg collider object
        if (isPlayer)
        {
            clone = Instantiate(damager, attackSummonPos.position, itemHeld.transform.rotation);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            clone.AddComponent(typeof(ToDamage));
            ToDamage TDmg = clone.GetComponent<ToDamage>();
            TDmg.dmgToDeal = baseDmg;
            TDmg.sourceName = gameObject.name;
            clone.GetComponent<Rigidbody2D>().AddForce(mouseDir * attackSpeed);
        }
        else if (!isPlayer)
        {
            Vector2 PlyrDir = FindObjectOfType<PlayerController3Dim>().transform.position - transform.position;
            itemHeld.transform.right = PlyrDir;
            clone = Instantiate(damager, attackSummonPos.position, itemHeld.transform.rotation);
            clone.AddComponent(typeof(ToDamage));
            ToDamage TDmg = clone.GetComponent<ToDamage>();
            TDmg.dmgToDeal = baseDmg;
            TDmg.sourceName = gameObject.name;
            clone.GetComponent<Rigidbody2D>().AddForce(mouseDir * attackSpeed);
        }
    }
}
