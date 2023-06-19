using UnityEngine;
using System;

public class BallColHandler : MonoBehaviour
{
    public float boostFactor = 2f; // Factor to boost the velocity by

    private Rigidbody rb;

    private MessagesBox msgBox;


    public MessagesBox MsgBox
    {
        //get; set;
        get
        {
            return msgBox;
        }
    
         set
         {
            if(value == null)
            {
                Debug.Log("ERROR-MESSAGE BOX NULL");
            }else
            {
                msgBox = value;
                Debug.Log("Message Box ASsigen Successfuly");
            }

         }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

       //check if message was left by the other collider, else leave a message for him 
        Collider key = GetComponent<Collider>();
        //this values is al
        ColissionInfo readColInfo;     
        if (msgBox.ColliderToCollisionData.TryGetValue(key, out readColInfo))
        {
            // Key exists in the dictionary
            // Access the value using the "value" variable
            Debug.Log("Ball Collider GOT MESSAGE:" + readColInfo);

           //this value should be dreived from the Collision info left by the other collider
           float boostFactorl = 0.7f;
           GetComponent<BallBooster>().Boost(boostFactorl);
        }
        else
        {
            // Key does not exist in the dictionary, leave a message for the other colldier to indicate that the ball has already 
            // finished the claculateions and the other colldier should invoke the action funciton with its local poitision info 
            Debug.Log("Ball Collider Got No Message, Adding message for the other collider");
            //reference to the other collider (the recipient)
            key = collision.collider;
            //a null value would have probably been fine, this way more readable i think. 
            ColissionInfo dummyCollisionInfo = new ColissionInfo();     
            Debug.Log("Ball adding Cilission Data to Dict");
            if (msgBox.ColliderToCollisionData.ContainsKey(key))
            {
                msgBox.ColliderToCollisionData[key] = dummyCollisionInfo;
            }
            else
            {
                msgBox.ColliderToCollisionData.Add(key, dummyCollisionInfo);
            }

        }


    

        /* 
        Vector3 newVelocity = rb.velocity; // Get the new velocity after the collision
        //newVelocity *= boostFactor; // Apply the boost factor to the velocity

        newVelocity *= (1 + boostFactor); // Apply the boost factor to the velocity

      
      
        rb.velocity = newVelocity; // Assign the boosted velocity back to the Rigidbody
 */

    }
}