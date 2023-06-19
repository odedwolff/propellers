using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropper : MonoBehaviour
{
    public Transform position;   // Position to spawn the prefab
    public float interval = 1f;  // Time interval between spawns

 

    private MessagesBox messageBox;

    public GameObject prefab;   // Prefab to be spawned

    private float timer = 0f;

    void Start(){
         messageBox = GetComponent<MessagesBox>();
        if (messageBox == null)
        {
            Debug.Log("ERROR- no message box at Ball droper!");
        }else{
            Debug.Log("Message Box Component Obtained at Ball Droper");
        }
    }

    private void Update()
    {
       /*  timer += Time.deltaTime;

        if (timer >= interval)
        {
            SpawnPrefab();
            timer = 0f;
        } */
         if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnPrefab();        
        }
    }

    private void SpawnPrefab()
    {
        GameObject instantiatedPrefab = Instantiate(prefab, position.position, position.rotation);
        BallColHandler ballColHanlder = instantiatedPrefab.GetComponent<BallColHandler>();
        ballColHanlder.MsgBox = messageBox;
    }
}
