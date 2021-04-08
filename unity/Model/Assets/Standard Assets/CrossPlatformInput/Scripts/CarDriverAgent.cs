using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityStandardAssets.Vehicles.Car;

public class CarDriverAgent : Agent
{
    // [SerializeField] private TrackCheckpoints trackCheckpoints;
    
    //public float xMinRange = -12.0f;
    //public float xMaxRange = -12.0f;
    //public float yMinRange = 0.0f;
    //public float yMaxRange = 0.0f;
    //public float zMinRange = 23.0f;
    //public float zMaxRange = 30.0f;

    //public Transform target;

    //public GameObject[] spawnObjects; // what prefabs to spawn,here car.

    private CarController carDriver;
    
    GameObject  CarAgent;
    //Rigidbody CarAgent;
    private void Awake()
    {
        carDriver = GetComponent<CarController>();


    }

    private void start()
    {
        //CarAgent = GameObject.FindGameObjectWithTag("Player");
        

    }

    void OnTriggerEnter(Collider other)
    {
            Debug.Log("HIT A Checkpoint");
            AddReward(+1f);
            EndEpisode();
    }

    //Need to make a function for checkpoint pos reward.
   // void hitCheckpoint() { 
    
   // }

    


    // void MakeThingToSpawn ()
    // {
    // 	Vector3 spawnPosition;

    // 	// get a random position between the specified ranges
    // 	spawnPosition.x = Random.Range (xMinRange, xMaxRange);
    // 	spawnPosition.y = Random.Range (yMinRange, yMaxRange);
    // 	spawnPosition.z = Random.Range (zMinRange, zMaxRange);

    // 	// determine which object to spawn
    // 	int objectToSpawn = Random.Range (0, spawnObjects.Length);

    // 	// actually spawn the game object
    // 	GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;
    // }



    public override void OnEpisodeBegin()
    {
        //   trackCheckpoints.ResetCheckpoint(transform);
        // MakeThingToSpawn();
        //this.CarAgent.angularVelocity = Vector3.zero;
        //this.CarAgent.velocity = Vector3.zero;
        this.transform.position = new Vector3(-12.0f, 0f, 30f);
        

    }

    public override void CollectObservations(VectorSensor sensor)
    {   //get obs from ray perception sensor.
        // float directionD = Vector3.Dot(transform.forward, checkpoint.transform.forward);
        // sensor.AddObservation(directionD);\
        
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
     
        float accel = actions.ContinuousActions[0];
        float turn = actions.ContinuousActions[1];

        carDriver.Move(turn, accel, accel, 0);

    }


    public override void Heuristic(in ActionBuffers actionsOut)
    { 
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxis("Vertical");
        continuousActions[1] = Input.GetAxis("Horizontal");

    }

    public void OnCollisionEnter(Collision collision)
    {
        //Check if car collides with wall
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("HIT A WALL ONCE");
            AddReward(-0.5f);
            EndEpisode();
            
        }

    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Keeps Hitting a wall");
            AddReward(-0.01f);
            EndEpisode();
        }

    }
}

