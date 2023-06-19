using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{

    private Vector3 defatultGravity; 

    public float gravityFactor = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        defatultGravity = Physics.gravity;
        Physics.gravity =  Physics.gravity * gravityFactor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
