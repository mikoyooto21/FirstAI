using BehaviorTree;
using UnityEngine;

public class Player : BehaviorTree.Tree
{
    public int speed;
    public Transform greenZone;
    protected override Node SetupTree(){
        Node root = new GoToPoint(transform, greenZone);
        return root;
    }
}
