using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    float speed=10.0f;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log("Entro");

        int n =Random.Range(0,other.gameObject.GetComponent<WayPoint>().waypointsPosibles.Length);
        //GameObject nextPoint = waypointsPosibles[n];
        //int n = 1;

        target=other.gameObject.GetComponent<WayPoint>().waypointsPosibles[n];
        transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
        
    }

}
