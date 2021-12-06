using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTime : MonoBehaviour
{
    int onTime = 30, offTime = 90;
    public int position = 0;
    BoxCollider boxCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        if(transform.rotation.eulerAngles.y == 0) position = 0;
        if(transform.rotation.eulerAngles.y == 90) position = 1;
        if(transform.rotation.eulerAngles.y == 180) position = 2;
        if(transform.rotation.eulerAngles.y == 270) position = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(position == 0){
            if(onTime == 0 && offTime == 0){
                onTime = 30;
                offTime = 90;
            }
            if(onTime > 0){
                // Collider off
                boxCollider.size = new Vector3(0.1f, 1.0f, 0.0f);
        
                onTime--;
                return;
            } 
            else {
                // Colider on
                boxCollider.size = new Vector3(0.1f, 1.0f, 1.0f);
                
                offTime--;
                return;
            }

        }

        if(position == 1){
            if(onTime == 0 && offTime == 0){
                onTime = 30;
                offTime = 90;
            }
            if(offTime > 60){
                // Collider on
                boxCollider.size = new Vector3(0.1f, 1.0f, 1.0f);
                
                offTime--;
                return;
            } 
            else if(onTime > 0) {
                // Colider of
                boxCollider.size = new Vector3(0.1f, 1.0f, 0.0f);
        
                onTime--;
                return;
            }
            else {
                // Colider on
                boxCollider.size = new Vector3(0.1f, 1.0f, 1.0f);
                
                offTime--;
                return;
            }

        }

        if(position == 2){
            if(onTime == 0 && offTime == 0){
                onTime = 30;
                offTime = 90;
            }
            if(offTime > 30){
                // Collider on
                boxCollider.size = new Vector3(0.1f, 1.0f, 1.0f);
                offTime--;
                return;
            } 
            else if(onTime > 0) {
                // Colider of
                boxCollider.size = new Vector3(0.1f, 1.0f, 0.0f);
                onTime--;
                return;
            }
            else {
                // Colider on
                boxCollider.size = new Vector3(0.1f, 1.0f, 1.0f);
                offTime--;
                return;
            }

        }

        if(position == 3){
            if(onTime == 0 && offTime == 0){
                onTime = 30;
                offTime = 90;
            }
            if(offTime > 0){
                // Collider on
                boxCollider.size = new Vector3(0.1f, 1.0f, 1.0f);
                offTime--;
                return;
            } 
            else {
                // Colider of
                boxCollider.size = new Vector3(0.1f, 1.0f, 0.0f);
                onTime--;
                return;
            }
        }
    }
}
