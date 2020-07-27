using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class MummyRay : Agent
{
    public Transform floor;
    public StageManager stateManager;

    private Rigidbody rb;
    public float moveSpeed = 2.0f;
    public float turnSpeed = 300.0f;

    private Material originMt;

    public override void Initialize()
    {
        MaxStep = 10000;
        rb = GetComponent<Rigidbody>();
        originMt = floor.GetComponent<MeshRenderer>().material;
    }

    public override void OnEpisodeBegin()
    {
        stateManager.MakeItems();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        float x = Random.Range(-23.0f, 23.0f);
        float z = Random.Range(-23.0f, 23.0f);

        transform.localPosition = new Vector3(x, 0.05f, z);
        transform.localRotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
    }

    public override void CollectObservations(Unity.MLAgents.Sensors.VectorSensor sensor)
    {

    }

    public override void OnActionReceived(float[] vectorAction)
    {

    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0.0f; //W, S (전/후) 1 , 2
        actionsOut[1] = 0.0f; //A, D (좌/우) 1 , 2

        //전진
        if (Input.GetKey(KeyCode.W))
        {
            actionsOut[0] = 1.0f;
        }
        //후진
        if (Input.GetKey(KeyCode.S))
        {
            actionsOut[0] = 2.0f;
        }
        //왼쪽 회전
        if (Input.GetKey(KeyCode.A))
        {
            actionsOut[1] = 1.0f;
        }
        //오른쪽 회전
        if (Input.GetKey(KeyCode.D))
        {
            actionsOut[1] = 2.0f;
        }
    }
}
