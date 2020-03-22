using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Refs  {

    public enum BehavState { FindSpace, FindBall, FindEnemy, PassBall, RunWithBall }
    
    public const float ARENA_HEIGHT = 10f;
    public const float ARENA_WIDTH = 10f;
    
    public static Vector3 FindFractionalPointBetween(Vector3 pos1, Vector3 pos2, float fraction)
    {
        Vector3 movePos = (pos2 - pos1) * fraction;
        Debug.Log(movePos);
        return movePos;
    }
}
