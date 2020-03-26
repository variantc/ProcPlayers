using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionsOfGame : MonoBehaviour {
    
    List<string> TeamWithBallStrings = new List<string> { "None", "A", "B" };
    List<string> BallVerticalLocationStrings = new List<string> { "Bottom", "Middle", "Top" };
    List<string> BallHorizontalLocationStrings = new List<string> { "Left", "Centre", "Right" };
    List<string> BallLocationStrings = new List<string> { "BottomLeft", "BottomCentre", "BottomRight",
                                                            "MiddleLeft", "MiddleCentre", "MiddleRight",
                                                            "TopLeft", "TopCentre", "TopRight" };
    List<string> BallRunnerStrings = new List<string> { "None", "A", "B" };
    List<string> BallMotionStrings = new List<string> { "Moving", "Stationary" };

    string teamWithBall = "None";
    string ballVerticalLocation = "Middle";
    string ballHorizontalLocation = "Centre";
    string ballLocation = "MiddleCentre";
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
    public string GetBallLocation()
    {
        return ballLocation;
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
        
        SetBallLocation(ballVerticalLocation + ballHorizontalLocation);
    }
    public void SetBallHorizontalLocation(string str)
    {
        if (BallHorizontalLocationStrings.Contains(str))
            ballHorizontalLocation = str;
        else
            Debug.LogError("Invalid string entered to ConditionsOfGame.SetBallHorizontalLocation");
        
        SetBallLocation(ballVerticalLocation + ballHorizontalLocation);
    }
    public void SetBallLocation(string str)
    {
        if (BallLocationStrings.Contains(str))
            ballLocation = str;
        else
            Debug.LogError("Invalid string entered to ConditionsOfGame.SetBallLocation");
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
