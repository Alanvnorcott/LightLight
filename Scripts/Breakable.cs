using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : Fighter
{
    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.ShowText("Destroyed", 25, Color.gray, transform.position, Vector3.up * 15, 0.5f);
    }
}
