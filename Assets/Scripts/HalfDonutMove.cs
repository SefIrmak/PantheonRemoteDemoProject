using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float repeatRate;
    public Transform pos1;
    public Transform pos2;
    bool turnBack;
    private Transform pushingStick;
    int loopTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //gets the first child object's (Moving Stick) transform
        pushingStick = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Starting in every 5 (repeatRate) seconds
        InvokeRepeating("MoveStick", 0, repeatRate);
        if (loopTime==3)
        {
            loopTime = 0;
        }
    }
    void MoveStick()
    {        
        if (loopTime <=2)
        {
            if (pushingStick.position.x <= pos1.position.x)
            {
                turnBack = true;
                loopTime++;
            }
            if (pushingStick.position.x >= pos2.position.x)
            {
                turnBack = false;
                loopTime++;
            }
            if (turnBack)
            {
                pushingStick.position = Vector3.MoveTowards(pushingStick.position, pos2.position, moveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                pushingStick.position = Vector3.MoveTowards(pushingStick.position, pos1.position, moveSpeed * Time.fixedDeltaTime);                
            }
        }
    }
}
