using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoider : Kinematic
{
    ObstacleAvoidence myMoveType;

    void Start()
    {
        myMoveType = new ObstacleAvoidence();
        myMoveType.character = this;
        myMoveType.target = myTarget;
    }

    protected override void Update()
    {
        steeringUpdate = myMoveType.getSteering();
        base.Update();
    }
}
