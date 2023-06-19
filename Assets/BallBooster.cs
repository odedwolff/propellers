using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBooster : MonoBehaviour
{   
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Boost(float boostFactor){
        Debug.Log("entering BallBooster.Boost(boostFactor=" + boostFactor + ")");
        
        Vector3 newVelocity = rb.velocity; // Get the new velocity after the collision
        //newVelocity *= boostFactor; // Apply the boost factor to the velocity

        newVelocity *= (.75f + boostFactor); // Apply the boost factor to the velocity

      
      
        rb.velocity = newVelocity; // Assign the boosted velocity back to the Rigidbody

    }
}