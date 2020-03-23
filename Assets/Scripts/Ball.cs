using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    ConditionsOfGame condition;

    private void Start()
    {
        condition = FindObjectOfType<ConditionsOfGame>();
    }

    private void FixedUpdate()
    {
        UpdatePositionCondition();
    }

    // Tells the ConditionsOfGame the position of this ball
    void UpdatePositionCondition ()
    {
        float posx = this.transform.position.x;
        float posy = this.transform.position.y;

        //Debug.Log(posx + "," + posy + " limit: " + Refs.ARENA_WIDTH * (-1 / 2));

        if (posx <= Refs.ARENA_WIDTH * (-1f/2))
            Debug.LogError("Ball:GetPosition : Invalid x value to send to ConditionsOfGame.SetBallHorizontalLocation");
        else if (posx <= Refs.ARENA_WIDTH * (1f/3 - 1f/2))
            condition.SetBallHorizontalLocation("LeftThird");
        else if (posx <= Refs.ARENA_WIDTH * (2f/3 - 1f/2))
            condition.SetBallHorizontalLocation("CentreThird");
        else if (posx <= Refs.ARENA_WIDTH * (1f/2))
            condition.SetBallHorizontalLocation("RightThird");
        else
            Debug.LogError("Ball:GetPosition : Invalid x value to send to ConditionsOfGame.SetBallHorizontalLocation");

        if (posx <= Refs.ARENA_HEIGHT * (-1f / 2))
            Debug.LogError("Ball:GetPosition : Invalid y value to send to ConditionsOfGame.SetBallVerticalLocation");
        else if (posx <= Refs.ARENA_HEIGHT * (1f/3 - 1f/2))
            condition.SetBallVerticalLocation("BottomThird");
        else if (posx <= Refs.ARENA_HEIGHT * (2f/3 - 1f/2))
            condition.SetBallVerticalLocation("MiddleThird");
        else if (posx <= Refs.ARENA_HEIGHT * (1f/2))
            condition.SetBallVerticalLocation("TopThird");
        else
            Debug.LogError("Ball:GetPosition : Invalid y value to send to ConditionsOfGame.SetBallVerticalLocation");
    }
}
