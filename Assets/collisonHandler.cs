using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisonHandler : MonoBehaviour
{

[SerializeField] float sceneLoadDelay=2f;
[SerializeField] AudioClip crashSound;
[SerializeField] AudioClip successSound;

[SerializeField] ParticleSystem crashParticles;
[SerializeField] ParticleSystem successParticles;
bool isTransitioning;
AudioSource audioSource;
bool collisionCheck=false;


 void Start() {
   audioSource=GetComponent<AudioSource>();
}
 void Update() {
    cheat();
}

     void cheat()
    {
        cheatDeath();
        cheatNextLevel();
    }

    void OnCollisionEnter(Collision other) 
    {
        

       
        if(other.gameObject.tag=="Obstacle")
        {
            
            onreload();
        }else
        if(other.gameObject.tag=="Finish")
        {
            onloadNextScene();
        }
    }

    void onreload()
    {
        if(collisionCheck==true)
        {
            return;
        }

        audioSource.PlayOneShot(crashSound);
        crashParticles.Play();

        GetComponent<rocketMovement>().enabled = false;

        Invoke("reloadScene", sceneLoadDelay);
    }
    void cheatNextLevel()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            loadNextScene();
        }
    }

    void cheatDeath()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // if CollisonCheck will be false it will activate the
            collisionCheck=!collisionCheck;
        }
    }

    

    void onloadNextScene()
    {
        
        audioSource.PlayOneShot(successSound);
        successParticles.Play();
        
        GetComponent<rocketMovement>().enabled=false;
        
        
        Invoke("loadNextScene", sceneLoadDelay);
    }
    void reloadScene()
    {
        int currentSceneIndex= SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void loadNextScene()
    {
        int totalScenes=SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex= SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex+1;
        if( nextSceneIndex==totalScenes)
        {
            nextSceneIndex=0;
            Debug.Log("next index= "+nextSceneIndex);
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    

}
