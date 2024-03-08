using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Collidable
{
    // Logic
    protected bool collected;

    protected override void onCollide(Collider2D coll)
    {
        if (coll.name == "Player")
            OnCollect();

    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
