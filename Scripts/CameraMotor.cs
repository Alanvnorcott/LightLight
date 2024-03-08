//CameraMotor

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    public float boundX = 0.3f;
    public float boundY = 0.15f;

    private void Start()
    {
        lookAt = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // This is to make sure that player is within bounds of X axis
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }

        }

        // This is to make sure that player is within bounds of Y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundX || deltaY< -boundX)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }

        }

        transform.position += new Vector3(delta.x, deltaY, 0);
    }
}
