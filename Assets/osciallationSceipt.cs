using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osciallationSceipt : MonoBehaviour


{
    // Start is called before the first frame update
    Vector3 startingPosition; // get starting position to start osciallation
    [SerializeField] Vector3 movementVector;    // set direction in which you want to oscillate
    float movementFactor;
    [SerializeField] float period =2f;  // timeperiod for cycle increase speed for oscialation
    

    void Start()
    {
       startingPosition=transform.position;
       Debug.Log("Starting Position"+ startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        objectMovement();
    }

    private void objectMovement()
    {
        float cycles= Time.time/period; // value increases with time
        const float tau = Mathf.PI*2;       // constant value which is equal to 2π
        float rawSin = Mathf.Sin(cycles*tau);   // going from -1 to 1

        movementFactor= (rawSin+1f)/2f; // recalculate to get value between 0 to 1 to keep cleaner
        Vector3 offset = movementVector * movementFactor; 
        Debug.Log("offset"+ offset);
        transform.position = startingPosition + offset*rawSin;
        Debug.Log("Transform Position"+ transform.position);
    }
}
