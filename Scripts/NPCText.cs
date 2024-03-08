using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCText : Collidable
{
    public string[] messages; // Change to an array of strings
    private int currentIndex = 0; // Keep track of the current index
    public float cooldown = 3.0f;
    private float lastShout;
    public int fontSize = 15;
    public Color color;

    protected override void Start()
    {
        base.Start();
        lastShout = -cooldown;
    }

    protected override void onCollide(Collider2D coll)
    {
        if (Time.time - lastShout > cooldown)
        {
            lastShout = Time.time;

            // Show the current message
            GameManager.instance.ShowText(messages[currentIndex], fontSize, color, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);

            // Move to the next message index or repeat the last one
            currentIndex = (currentIndex + 1) % messages.Length;
        }
    }
}
