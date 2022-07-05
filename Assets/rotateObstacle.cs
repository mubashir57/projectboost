using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movementSpeed=1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(movementSpeed,0f,0f);
    }
}
