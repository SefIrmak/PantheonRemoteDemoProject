using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Transform pos1;
    public Transform pos2;
    bool turnBack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x >= pos1.position.x)
        {
            turnBack = true;
        }
        if (transform.position.x <= pos2.position.x)
        {
            turnBack = false;
        }
        if (turnBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2.position, moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1.position, moveSpeed * Time.fixedDeltaTime);
        }
    }
}
