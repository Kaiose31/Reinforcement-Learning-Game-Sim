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
    
    public float xMinRange = -12.0f;
    public float xMaxRange = -12.0f;
    public float yMinRange = 0.0f;
    public float yMaxRange = 0.0f;
    public float zMinRange = 23.0f;
    public float zMaxRange = 30.0f;

    public Transform target;

    public GameObject[] spawnObjects; // what prefabs to spawn,here car.

    private CarController carDriver;
    private GameObject[] Obstacle;

    Rigidbody CarAgent;
    private void Awake()
    {
        carDriver = GetComponent<CarController>();
        Obstacle = GameObject.FindGameObjectsWithTag("Obstacle");

    }

    private void start()
    {
        CarAgent = GetComponent<Rigidbody>();

    }

    void OnTriggerEnter(Collider other)
    {
        //  if (Obstacle[0] || Obstacle[1]|| Obstacle[2]||Obstacle[3] || Obstacle[4] || Obstacle[5])
        // {
        
            Debug.Log("HIT A Checkpoint");
            AddReward(1f);
            //EndEpisode();

        // }
        // if (CarAgent)
        // {
        //     AddReward(1f);
        // }
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
        //carDriver.Move(0f, 0f, 0f, 0f);
        // MakeThingToSpawn();

        this.CarAgent.angularVelocity = Vector3.zero;
        this.CarAgent.velocity = Vector3.zero;
        this.transform.position = new Vector3(-12.0f, 0f, 30f);



    }

    public override void CollectObservations(VectorSensor sensor)
    {   //get obs from ray perception sensor.
        // float directionD = Vector3.Dot(transform.forward, checkpoint.transform.forward);
        // sensor.AddObservation(directionD);\

    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        float accel = 0f;
        float turn = 0f;


        switch (actions.DiscreteActions[0])
        {
            case 0: accel = 0f; break;
            case 1: accel = +1f; break;
            case 2: accel = -1f; break;
        }
        switch (actions.DiscreteActions[1])
        {
            case 0: turn = 0f; break;
            case 1: turn = +1f; break;
            case 2: turn = -1f; break;
        }


        carDriver.Move(turn, accel, accel, 0f);

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        int forwardAction = 0;
        if (Input.GetKey(KeyCode.UpArrow)) forwardAction = 1;
        if (Input.GetKey(KeyCode.DownArrow)) forwardAction = 2;

        int turnAction = 0;
        if (Input.GetKey(KeyCode.RightArrow)) turnAction = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) turnAction = 2;

        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        discreteActions[0] = forwardAction;
        discreteActions[1] = turnAction;


    }

    public void OnCollisionEnter(Collision collision)
    {
        //Check if car collides with wall
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("HIT A WALL ONCE");
            AddReward(-0.5f);
            
        }

    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Keeps Hitting a wall");
            AddReward(-1f);
        }

    }
}

