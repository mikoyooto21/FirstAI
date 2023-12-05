using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
    
    [SerializeField] private CharacterPathfindingMovementHandler characterPathfinding;
    private Pathfinding pathfinding;
    [SerializeField] private Transform _greenZone;
    [SerializeField] private Transform _parent;

    private void Start() {
        pathfinding = new Pathfinding(20, 20);
    }

    private void Update() {
        
        pathfinding.GetGrid().GetXZ(_greenZone.position, out int x, out int z);
        List<PathNode> path = pathfinding.FindPath(0, 0, x, z);
        if (path != null) {
            for (int i=0; i<path.Count - 1; i++) {
                Debug.DrawLine(new Vector3(path[i].x, path[i].z) * 10f + Vector3.one * 5f, new Vector3(path[i+1].x, path[i+1].z) * 10f + Vector3.one * 5f, Color.green, 5f);
            }
        }
        characterPathfinding.SetTargetPosition();
        foreach(Transform child in _parent){
            if(child.childCount>3)
                pathfinding.GetNode(x, z).SetIsWalkable(!pathfinding.GetNode(x, z).isWalkable);
        }
    }

}
