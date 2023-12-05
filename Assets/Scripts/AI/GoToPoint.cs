using UnityEngine;
using BehaviorTree;
using System.Collections.Generic;
using System;

public class GoToPoint : Node
{
    private Transform _greenZone;
    [SerializeField] private Transform _cells;
    private Transform _transform;
    private Pathfinding pathfinding;

    public GoToPoint(Transform transform, Transform greenZone){
        _transform = transform;
        _greenZone = greenZone;
        pathfinding = new Pathfinding(20, 20);
    }

    public override NodeState Evaluate(){

        if(_transform.position != _greenZone.position){
            pathfinding.GetGrid().GetXZ(_greenZone.position, out int x, out int z);
            List<PathNode> path = pathfinding.FindPath(1, 1, x, z);
            foreach (Transform cell in _cells)
                for(int row = 1; row < x+1; row++){
                    for(int col = 1; col < x+1; col++){
                        Vector3 temp = new Vector3(row, 0, col);
                        if(cell.position == temp && cell.childCount > 3)
                            pathfinding.GetNode(x, z).SetIsWalkable(!pathfinding.GetNode(x, z).isWalkable);
                    }
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}
