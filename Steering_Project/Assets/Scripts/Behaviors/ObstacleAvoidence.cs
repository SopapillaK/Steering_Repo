using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ObstacleAvoidence : Seek
{
    // the minimum distance to hit a wall (i.e. how far to avoid 
    // collision) should be greater than the radius of the character.
    public float avoidDistance = 3f;

    // The distance to look ahead for a collision
    public float lookahead = 5f;

    protected override Vector3 getTargetPosition()
    {
        // Cast a ray
        RaycastHit hit;
        if (Physics.Raycast(character.transform.position, character.linearVelocity, out hit, lookahead))
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized * hit.distance, Color.red, 0.5f);
            Debug.Log("Hit " + hit.collider);
            return hit.point + (hit.normal * avoidDistance);
        }
        else
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized * lookahead, Color.green, 0.5f);
            Debug.Log("safe");
            // nothing to avoid
            return base.getTargetPosition();
        }
    }

}
