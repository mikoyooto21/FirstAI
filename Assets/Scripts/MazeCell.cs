using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftWall;

    [SerializeField]
    private GameObject _rightWall;

    [SerializeField]
    private GameObject _frontWall;

    [SerializeField]
    private GameObject _backWall;

    [SerializeField]
    private GameObject _unvisitedBlock;

    public bool IsVisited { get; private set; }

    public void Visit()
    {
        IsVisited = true;
    }

    public void ClearLeftWall()
    {
        Destroy(_leftWall);
    }

    public void ClearRightWall()
    {
        Destroy(_rightWall);
    }

    public void ClearFrontWall()
    {
        Destroy(_frontWall);
    }

    public void ClearBackWall()
    {
        Destroy(_backWall);
    }
}