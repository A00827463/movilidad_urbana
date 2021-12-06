using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    float speed = 1f;
    public Transform target; 
    // int waitTime = 0;
    public bool wait = false;

    void Start()
    {
        transform.LookAt(new Vector3(target.position.x , transform.position.y , target.position.z));
    }

    void Update()
    {
        if(wait == true) return;
        transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
    }


    void OnTriggerEnter(Collider other) {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        if(other.tag=="WayPoint"){
            target=other.gameObject.GetComponent<WayPoint>().nexPoint;
            transform.LookAt(new Vector3(target.position.x , transform.position.y , target.position.z));
        }        
        if(other.tag=="Stop"){
            // waitTime = 10;
            wait = true;
        }
        // if(other.tag=="Go"){
        //     // waitTime = 10;
        //     wait = false;
        // }  
    }
    void OnTriggerExit(Collider other) {
        wait = false;
    }
}
