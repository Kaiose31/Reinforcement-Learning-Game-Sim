using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityStandardAssets.Vehicles.Car;

public class CarDriverAgent : Agent
{
    [SerializeField] private TrackCheckpoints trackCheckpoints;
    [SerializeField] private Transform spawnPosition;

    private CarController carDriver;



    private void Awake()
    {
        carDriver = GetComponent<CarController>();

    }
    public GameObject CarAgent;
    private void start()
    {
        
        CarAgent = GameObject.FindGameObjectWithTag("Car");
    }

    void OnTriggerEnter(Collider other)
    {
        if (CarAgent)
        {
            AddReward(1f);
        }
    }



    public override void OnEpisodeBegin()
    {

        //   trackCheckpoints.ResetCheckpoint(transform);
        carDriver.Move(0f, 0f, 0f, 0f);
       //Set transform to spawnpos / reset checkpoint.

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
        if (Input.GetKey(KeyCode.UpArrow)) forwardAction = 2;

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
            AddReward(-0.5f);
            
        }

    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            AddReward(-1f);
        }

    }
}

