using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckForRedDots : Node
{
    private Transform _transform;

    private List<Transform> redDots = new List<Transform>();

    private void Update(){

    }

    public CheckForRedDots(Transform transform, Transform greenZone){
        _transform = transform;
        //_greenZone = greenZone;
    }

    public override NodeState Evaluate(){

        //if(Vector3.Distance(_transform.position, _greenZone.position) > 0){
            //_transform.position = Vector3.MoveTowards(_transform.position, _greenZone.position, 5 * Time.deltaTime);
            //_transform.LookAt(_greenZone.position);
        //}

        state = NodeState.RUNNING;
        return state;
    }
}
