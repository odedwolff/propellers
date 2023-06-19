using UnityEngine;

public class StickCollissionHandler : MonoBehaviour
{

    public float contactsFactor = 2.0f;

    public GameObject messageBoxGameObject;

    private MessagesBox messageBox;
    void Start(){
        Debug.Log("object dimention" + GetComponent<Collider>().bounds.size);
        messageBox = messageBoxGameObject.GetComponent<MessagesBox>();
        if (messageBox == null)
        {
            Debug.Log("ERROR- no message box!");
        }else{
            Debug.Log("Message Box Obtained at StickCollsion handler");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        

        //assuming a single contact point
        Vector3 localPosition = transform.InverseTransformPoint(collision.contacts[0].point);
        Debug.Log("Local position of collision recorded at stick: " + localPosition);
        
        Debug.Log("@Stick CollisionHandler, messageBox.ColliderToCollisionData = " + messageBox.ColliderToCollisionData);
        
        
        //check if message was left by the other collider, else leave a message for him. if a message was in fact 
        //left, it only serves to indicate that the other colider already ran its distictive onCollision() 
        Collider key = GetComponent<Collider>();
        ColissionInfo colInfo1;       
        if (messageBox.ColliderToCollisionData.TryGetValue(key, out colInfo1))
        {
            // Key exists in the dictionary
            // Access the value using the "value" variable
            Debug.Log("Stick Collider GOT MESSAGE:" + colInfo1);

            
            //derive the boost factor from the local colission position
            float boostFactorl = localPosition[0];
            collision.collider.GetComponent<BallBooster>().Boost(boostFactorl);
        }
        else
        {
            // Key does not exist in the dictionary
            Debug.Log("Stick Collider Got No Message, Adding message for the other collider");
            key = collision.collider;
            //so leave him the contacts info, and he will take care of the rest 
            colInfo1 = new ColissionInfo();
            colInfo1.LocalHitPosition = localPosition;
            Debug.Log("Stick adding Cilission Data to Dict");
            if (messageBox.ColliderToCollisionData.ContainsKey(key))
            {
                messageBox.ColliderToCollisionData[key] = colInfo1;
            }
            else
            {
                messageBox.ColliderToCollisionData.Add(key, colInfo1);
            }

        }


    }
}