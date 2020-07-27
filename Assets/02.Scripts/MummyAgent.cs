using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class MummyAgent : Agent
{

#region MLAGENT_CALLBACK

    //에이전트 초기화
    public override void Initialize()
    {

    }

    //학습을 시작할때(에피소드) 마다 호출되는 함수
    public override void OnEpisodeBegin()
    {

    }

    //주변환경을 관찰할 때 호출
    public override void CollectObservations(Unity.MLAgents.Sensors.VectorSensor sensor)
    {

    }

    //브레인으로 부터 전달받은 명령을 수행하는 함수
    public override void OnActionReceived(float[] vectorAction)
    {

    }

    //플레이어의 입력값으로 명령을 수행하는 함수
    public override void Heuristic(float[] actionsOut)
    {

    }

#endregion

#region UNITY_CALLBACK

#endregion

#region USER_DEFINE_FUNCS

#endregion

}
