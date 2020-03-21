using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Refs  {

    public enum BehavState { FindSpace, FindBall, FindEnemy, PassBall, RunWithBall }

    public static Vector3 FindFractionalPointBetween(Vector3 pos1, Vector3 pos2, float fraction)
    {
        Vector3 movePos = (pos2 - pos1) * fraction;
        return movePos;
    }
}
