using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    [SerializeField] private bool isClockwise;
    [SerializeField] private float rotateSpeed;
    

    void FixedUpdate()
    {
        if (isClockwise)
        {
            transform.Rotate(0, 0, -rotateSpeed);
        }
        else
            transform.Rotate(0, 0, rotateSpeed);

    }
}
