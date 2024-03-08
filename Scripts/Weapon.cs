//Weapon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage structure
    public int[] damagePoint = { 1, 3, 6, 8, 10, 12, 14, 16, 18, 25, 40 };
    public float[] pushForce = { 2.0f, 2.2f, 2.5f, 3f, 3.2f, 3.6f, 3.8f, 4f, 4.6f, 4.8f, 5.0f };

    // Crit chance
    public float[] critChance = { 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f, 0.5f, 0.55f, 0.6f };

    // Upgrade
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;

    // Swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void onCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;

            // Calculate crit chance
            float randomValue = Random.value;
            bool isCrit = randomValue < critChance[weaponLevel];

            // Create a new dmg object, then send it to the fighter that was hit
            Damage dmg = new Damage
            {
                damageAmount = CalculateDamage(isCrit),
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private int CalculateDamage(bool isCrit)
    {
        int baseDamage = damagePoint[weaponLevel];
        if (isCrit)
        {
            // Apply crit multiplier, for example, doubling the damage
            return Mathf.RoundToInt(baseDamage * 2);
        }
        else
        {
            return baseDamage;
        }
    }

    private void Swing()
    {
        anim.SetTrigger("Swing");

        Debug.Log("Swing");
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

        // Change stats
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
