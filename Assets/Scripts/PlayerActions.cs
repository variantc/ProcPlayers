using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    // THROW BALL
    public void ThrowBall(GameObject ball, Vector3 target)
    {
        
    }

    // MOVE TO 
    // Return true when arrived
    public bool MoveTo(GameObject go, Vector3 moveTar, float speed)
    {
        float moveBuffer = 0.1f;
        Vector3 moveVector = moveTar - go.transform.position;

        if (moveVector.magnitude > moveBuffer)
        {
            go.transform.position += moveVector.normalized * speed * Time.deltaTime;
        }
        else
        {
            this.transform.position = moveTar;
            // return true for arrived
            return true;
        }
        return false;
    }
}
