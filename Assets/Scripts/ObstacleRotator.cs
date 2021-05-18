using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private Transform rotatingObject;
    // Start is called before the first frame update
    void Start()
    {
        rotatingObject = this.gameObject.GetComponent<Transform>() as Transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotating the Object
        rotatingObject.Rotate(0, rotateSpeed, 0);
    }
}
