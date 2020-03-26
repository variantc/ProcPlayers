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

        string widthString = "";
        string heightString = "";

        //Debug.Log(posx + "," + posy + " limit: " + Refs.ARENA_WIDTH * (-1 / 2));

        //if (posx <= Refs.ARENA_WIDTH * (-1f/2))
        //    Debug.LogError("Ball:GetPosition : Invalid x value to send to ConditionsOfGame.SetBallHorizontalLocation");
        //else if (posx <= Refs.ARENA_WIDTH * (1f/3 - 1f/2))
        //    condition.SetBallHorizontalLocation("Left");
        //else if (posx <= Refs.ARENA_WIDTH * (2f/3 - 1f/2))
        //    condition.SetBallHorizontalLocation("Centre");
        //else if (posx <= Refs.ARENA_WIDTH * (1f/2))
        //    condition.SetBallHorizontalLocation("Right");
        //else
        //    Debug.LogError("Ball:GetPosition : Invalid x value to send to ConditionsOfGame.SetBallHorizontalLocation");

        if (posx <= Refs.ARENA_WIDTH * (-1f / 2))
            Debug.LogError("Ball:GetPosition : Invalid x value to send to ConditionsOfGame.SetBallHorizontalLocation");
        else if (posx <= Refs.ARENA_WIDTH * (1f / 3 - 1f / 2))
            widthString = "Left";
        else if (posx <= Refs.ARENA_WIDTH * (2f / 3 - 1f / 2))
            widthString = "Centre";
        else if (posx <= Refs.ARENA_WIDTH * (1f / 2))
            widthString = "Right";
        else
            Debug.LogError("Ball:GetPosition : Invalid x value to send to ConditionsOfGame.SetBallHorizontalLocation");

        //if (posx <= Refs.ARENA_HEIGHT * (-1f / 2))
        //    Debug.LogError("Ball:GetPosition : Invalid y value to send to ConditionsOfGame.SetBallVerticalLocation");
        //else if (posx <= Refs.ARENA_HEIGHT * (1f/3 - 1f/2))
        //    condition.SetBallVerticalLocation("Bottom");
        //else if (posx <= Refs.ARENA_HEIGHT * (2f/3 - 1f/2))
        //    condition.SetBallVerticalLocation("Middle");
        //else if (posx <= Refs.ARENA_HEIGHT * (1f/2))
        //    condition.SetBallVerticalLocation("Top");
        //else
        //    Debug.LogError("Ball:GetPosition : Invalid y value to send to ConditionsOfGame.SetBallVerticalLocation");

        if (posy <= Refs.ARENA_HEIGHT * (-1f / 2))
            Debug.LogError("Ball:GetPosition : Invalid y value to send to ConditionsOfGame.SetBallVerticalLocation");
        else if (posy <= Refs.ARENA_HEIGHT * (1f / 3 - 1f / 2))
            heightString = "Bottom";
        else if (posy <= Refs.ARENA_HEIGHT * (2f / 3 - 1f / 2))
            heightString = "Middle";
        else if (posy <= Refs.ARENA_HEIGHT * (1f / 2))
            heightString = "Top";
        else
            Debug.LogError("Ball:GetPosition : Invalid y value to send to ConditionsOfGame.SetBallVerticalLocation");
        
        condition.SetBallLocation(heightString + widthString);
    }
}
