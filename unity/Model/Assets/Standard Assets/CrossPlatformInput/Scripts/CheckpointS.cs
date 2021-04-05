using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class CheckpointS : MonoBehaviour
{
    private bool isColliding;
    public TrackCheckpoints trackCheckpoints;
    public GameObject Chassis;
    public void Start() {
        Chassis = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void Update() { }
    
    
    void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;
        isColliding = true;
        if (Chassis)
        {
            //Debug.Log("PASSED ");

            trackCheckpoints.PlayerThroughCheckpoint(this);
        }

    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints) {
        this.trackCheckpoints = trackCheckpoints; 
   
    }


}



