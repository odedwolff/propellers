using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesBox : MonoBehaviour
{
    
    private Dictionary<Collider, ColissionInfo> colliderToCollisionData = new Dictionary<Collider, ColissionInfo>(); 

    public Dictionary <Collider, ColissionInfo> ColliderToCollisionData
    {
        set{
            colliderToCollisionData = value;
        }
        get{
            //Debug.Log("MessageBox.Get()");
            return colliderToCollisionData;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
