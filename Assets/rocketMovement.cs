using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb ;
    [SerializeField] float thrustspeed=1000f;
    [SerializeField] AudioClip rocketSound;
    [SerializeField] ParticleSystem rocketThrust;
    [SerializeField] ParticleSystem LeftsideThrust;
    [SerializeField] ParticleSystem rightSideThrust;
    
    
    
    float xAngle=0f;
    float yAngle=0f;
    [SerializeField] float rotationThrust=100f;
    AudioSource adsource;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        adsource=GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        processUpThrust();
        processRotation();
    }
    void processUpThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else stopThrusting();
    }

     void stopThrusting()
    {
        adsource.Stop();
        rocketThrust.Stop();
        
    }

    public void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustspeed * Time.deltaTime);
        if ( !adsource.isPlaying)
        {
            adsource.PlayOneShot(rocketSound);
        }
        if(!rocketThrust.isPlaying)
        {
        
            rocketThrust.Play();
        }
    }

    public void stopRotating()
    {
        
        LeftsideThrust.Stop();
        rightSideThrust.Stop();
    }

    void processRotation()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
            

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }
        else
        {
            LeftsideThrust.Stop();
            
            
        }
        
        
    }

    private void RotateLeft()
    {
        if (!rightSideThrust.isPlaying) { rightSideThrust.Play();}
        else{
            rightSideThrust.Stop();
        }
        rotationm(-rotationThrust);
    }

    public void RotateRight()
    {
        rotationm(rotationThrust);
        LeftsideThrust.Play();
    }

    

    public void rotationm(float zAngle)
    {
        rb.freezeRotation=true;
        transform.Rotate(-Vector3.forward * zAngle * Time.deltaTime);
        rb.freezeRotation=false;

    }
}
