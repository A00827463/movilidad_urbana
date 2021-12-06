using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    float speed = 1f;
    public Transform target; 
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
        if(other.tag=="WayPoint" && other.gameObject.GetComponent<WayPoint>().waypointsPosibles==null){
             //Debug.Log("Entro");

            int n =Random.Range(0,other.gameObject.GetComponent<WayPoint>().waypointsPosibles.Length);
            
            // target=other.gameObject.GetComponent<WayPoint>().nexPoint;
            
            target=other.gameObject.GetComponent<WayPoint>().waypointsPosibles[n];
            transform.LookAt(new Vector3(target.position.x , transform.position.y , target.position.z));
        }        
        if(other.tag=="Stop"){
            // waitTime = 10;
            wait = true;
        }
    }
    void OnTriggerExit(Collider other) {
        wait = false;
    }
}
