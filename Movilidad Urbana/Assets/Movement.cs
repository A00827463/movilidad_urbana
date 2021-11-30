using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float speed=1.0f;

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

    void OnTriggerEnter(Collider other){
        // if(other.tag=="WayPoint"){
        //     target=other.gameObject.GetComponent<WayPoint>().nexPoint;
        //     transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
        // }
    }

}
