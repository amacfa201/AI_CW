using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using MLAgents;


public class SeekAgent : Agent
{
    public float currentReward;
    public int myScore;
    private RayPerception rayPer;
    public Rigidbody rigidbody;
    public float _Distance;
    public float dec;
    public float inc;
    TargetSpawner ts;

    private void Start()
    {
        ts = this.gameObject.transform.parent.GetComponent<TargetSpawner>();
    }
    public override void InitializeAgent()
    {
        rayPer = GetComponent<RayPerception>();
    }

    public override void CollectObservations()
    {
        AddVectorObs(transform.position);
        const float rayDistance = 70f;
        float[] rayAngles = { 20f, 90f, 160f, 45f, 135f, 70f, 110f };
        float[] rayAngles1 = { 25f, 95f, 165f, 50f, 140f, 75f, 115f };
        float[] rayAngles2 = { 15f, 85f, 155f, 40f, 130f, 65f, 105f };

        string[] detectableObjects = { "wall", "Room", "Target"};
        AddVectorObs(rayPer.Perceive(rayDistance, rayAngles, detectableObjects, 0f, 0f));
        AddVectorObs(rayPer.Perceive(rayDistance, rayAngles1, detectableObjects, 0f, 5f));
        AddVectorObs(rayPer.Perceive(rayDistance, rayAngles2, detectableObjects, 0f, 10f));
       
        AddVectorObs(transform.InverseTransformDirection(rigidbody.velocity));
    }

    public void MoveAgent(float[] act)
    {
       
    }

    private void Update()
    {
        //print("reward= " + GetReward());
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {

        
        Vector3 cpn = Vector3.zero;
        cpn.x = vectorAction[0];
        cpn.z = vectorAction[1];
        rigidbody.AddForce(cpn * 25);
        AddReward(-1f / agentParameters.maxStep); //makes them move faster
        //AgentDistance();
    }

    public override void AgentReset()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            SetReward(30f);
            Done();
            ts.SpawnTarget();
            Destroy(collision.gameObject, 0.5f);
            UpdateStats();
            myScore++;
            print("reward inc = " + GetReward());

        }

        if (collision.gameObject.CompareTag("wall"))
        {

            SetReward(-31f);
            //transform.position = new Vector3(0, 0.6f, 0);
            print("reward dec = " + GetReward());
            Done();
        }
        if (collision.gameObject.CompareTag("Room"))
        {
            SetReward(-2f);
            transform.position = new Vector3(0, 0.6f, 0);
            Done();
        }
    }


    private void AgentDistance()
    {
        float temporyDistance = Vector3.Distance(transform.position, ts.transform.position);
        if (temporyDistance < _Distance)
        {
            _Distance = temporyDistance;
            AddReward(1f);
            inc++;
        }
        else if (temporyDistance > _Distance)
        {
            _Distance = temporyDistance;
            AddReward(-1f);
            dec++;
        }
    }







    public override void AgentOnDone()
    {

    }

    void UpdateStats()
    {
        currentReward = GetCumulativeReward();
        
    }
}
