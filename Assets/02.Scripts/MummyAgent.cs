using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class MummyAgent : Agent
{
    public Transform targetTr;  //목표물의 Transform
    private Transform tr;       //에이젼트의 Transform
    private Rigidbody rb;

#region MLAGENT_CALLBACK

    //에이전트 초기화
    public override void Initialize()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    //학습을 시작할때(에피소드) 마다 호출되는 함수
    public override void OnEpisodeBegin()
    {
        //물리력을 모두 초기화
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        //에이전트의 위치를 불규칙하게 조정
        tr.localPosition = new Vector3(Random.Range(-4.0f, 4.0f)
                                    , 0.05f
                                    , Random.Range(-4.0f, 4.0f));

        targetTr.localPosition = new Vector3(Random.Range(-4.0f, 4.0f)
                                            , 0.55f
                                            , Random.Range(-4.0f, 4.0f));                             
    }

    //주변환경을 관찰할 때 호출
    public override void CollectObservations(Unity.MLAgents.Sensors.VectorSensor sensor)
    {
        sensor.AddObservation(targetTr.localPosition); //3
        sensor.AddObservation(tr.localPosition);       //3
        sensor.AddObservation(rb.velocity.x);          //1
        sensor.AddObservation(rb.velocity.z);          //1
    }

    //브레인으로 부터 전달받은 명령을 수행하는 함수
    public override void OnActionReceived(float[] vectorAction)
    {
        float h = Mathf.Clamp(vectorAction[0], -1.0f, +1.0f);  //좌/우 화살표
        float v = Mathf.Clamp(vectorAction[1], -1.0f, +1.0f);  //상/하 화살표

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        rb.AddForce(dir * 50.0f);

        SetReward(-0.001f);
    }

    //플레이어의 입력값으로 명령을 수행하는 함수
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Horizontal");    //-1.0f ~ 0.0f ~ +1.0f
        actionsOut[1] = Input.GetAxis("Vertical");      //-1.0f ~ 0.0f ~ +1.0f

        Debug.Log($"h={actionsOut[0]} / v={actionsOut[1]}");
    }

#endregion

#region UNITY_CALLBACK

#endregion

#region USER_DEFINE_FUNCS

#endregion

}
