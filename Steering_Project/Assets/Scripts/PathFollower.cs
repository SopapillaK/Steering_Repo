using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PathFollower : Kinematic
{
    FollowingPath myMoveType;
    LookWhereGoing myRotateType;

    public GameObject[] targets;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new FollowingPath();
        myMoveType.character = this;

        myMoveType.targets = targets;

        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}
