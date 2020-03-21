using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionsOfGame : MonoBehaviour {
    
    List<string> TeamWithBallStrings = new List<string> { "None", "A", "B" };
    List<string> BallVerticalLocationStrings = new List<string> { "BottomThird", "MiddleThird", "TopThird" };
    List<string> BallHorizontalLocationStrings = new List<string> { "LeftThird", "CentreThird", "RightThird" };
    List<string> BallRunnerStrings = new List<string> { "None", "A", "B" };
    List<string> BallMotionStrings = new List<string> { "Moving", "Stationary" };

    string teamWithBall = "None";
    string ballVerticalLocation = "MiddleThird";
    string ballHorizontalLocation = "CentreThird";
    string ballRunner = "None";
    string ballMotion = "Stationary";
   
    // Getters
	public string GetTeamWithBall()
    {
        return teamWithBall;
    }
    public string GetBallVerticalLocation()
    {
        return ballVerticalLocation;
    }
    public string GetBallHorizontalLocation()
    {
        return ballHorizontalLocation;
    }
    public string GetBallRunner()
    {
        return ballRunner;
    }
    public string GetBallMotion()
    {
        return ballMotion;
    }

    // Setters
    public void SetTeamWithBall(string str)
    {
        if (TeamWithBallStrings.Contains(str))
            teamWithBall = str;
        else
            Debug.LogError("Invalid string entered to ConditionsOfGame.SetTeamWithBall");
    }
    public void SetBallVerticalLocation(string str)
    {
        if (BallVerticalLocationStrings.Contains(str))
            ballVerticalLocation = str;
        else
            Debug.LogError("Invalid string entered to ConditionsOfGame.SetBallVerticalLocation");
    }
    public void SetBallHorizontalLocation(string str)
    {
        if (BallHorizontalLocationStrings.Contains(str))
            ballHorizontalLocation = str;
        else
            Debug.LogError("Invalid string entered to ConditionsOfGame.SetBallHorizontalLocation");
    }
    public void SetBallRunner(string str)
    {
        if (BallRunnerStrings.Contains(str))
            ballRunner = str;
        else
            Debug.LogError("Invalid string entered to ConditionsOfGame.SetBallRunner");
    }
    public void SetBallMotion(string str)
    {
        if (BallMotionStrings.Contains(str))
            ballMotion = str;
        else
            Debug.LogError("Invalid string entered to ConditionsOfGame.SetBallMotion");
    }
}
