using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    // THROW BALL
    public void ThrowBall(Ball ball, Vector3 target)
    {
        Debug.Log("THROWWWW");
    }

    // MOVE TO 
    // Return true when arrived
    public bool MoveTo(Player player, Vector3 moveTar, float speed)
    {
        float moveBuffer = 0.1f;
        Vector3 moveVector = moveTar - player.transform.position;

        if (moveVector.magnitude > moveBuffer)
        {
            player.transform.position += moveVector.normalized * speed * Time.deltaTime;
        }
        else
        {
            this.transform.position = moveTar;
            // return true for arrived
            return true;
        }
        return false;
    }

    //void AttackClosestEnemy()
    //{
    //    FindClosest("enemy");
    //}

    //// must be passed either "friend" or "enemy""
    //Player FindClosest(Player player, string team)
    //{
    //    Player closest = null;
    //    float dist = float.PositiveInfinity;
    //    if (team == "friend")
    //    {
    //        foreach (Player p in friends)
    //        {
    //            float currDist = (p.transform.position - this.transform.position).magnitude;
    //            if (currDist < dist)
    //            {
    //                dist = currDist;
    //                closest = p;
    //            }
    //        }
    //    }
    //    else if (team == "enemy")
    //    {
    //        foreach (Player p in friends)
    //        {
    //            float currDist = (p.transform.position - this.transform.position).magnitude;
    //            if (currDist < dist)
    //            {
    //                dist = currDist;
    //                closest = p;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("FindClosest must be passed either \"friend\" or \"enemy\"");
    //    }
    //    if (closest == null)
    //        Debug.LogError(team + " player not found");
    //    return closest;
    //}

    //void HelpClosestFriend()
    //{
    //    FindClosest("friend");
    //}
    void FindBall()
    {
    }
    void MoveToEnemyGoalLine()
    {
    }
    void MoveToFriendlyGoalLine()
    {
    }
    void PassBall()
    {
    }
    void RunWithBall()
    {
    }
    void DropBall()
    {
    }
}
