using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    GameController gc;
    ConditionsOfGame cg;
    public Material[] materials;

    // STATS:
    [SerializeField]
    float health;
    [SerializeField]
    float energy;
    [SerializeField]
    float stamina;
    [SerializeField]
    float strength;
    [SerializeField]
    float speed;

    // MOVEMENT:
    Vector3 moveTarget;
    bool hasTarget = false;

    // PLAYER LISTS
    public List<Player> friends;
    public List<Player> enemies;

    [SerializeField]
    string team;
    public string Team
    {
        get
        {
            return team;
        }
        set
        {
            if (value == "A" || value == "B")
                team = value;
            else
                Debug.LogError("Bad team name - should be A or B");
        }
    }

    float[] traitWeights;
    public int numTraits;

    // BEHAVIOUR STATE:
    Refs.BehavState behavState = Refs.BehavState.FindBall;
    
    private void Start()
    {
        gc = FindObjectOfType<GameController>();
        cg = FindObjectOfType<ConditionsOfGame>();

        AssignTeamColour();

        numTraits = System.Enum.GetNames(typeof(Refs.BehavState)).Length;

        // Set up stats and state weights with random values
        SetUpStats();
        SetUpStatesWeights();

        // set initial random target
        //SetNewTarget(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f));

        SetNewTarget(Refs.FindFractionalPointBetween(gc.ball.transform.position, 
                                                        new Vector3(
                                                        gc.ball.transform.position.x,
                                                        Refs.ARENA_HEIGHT/2,
                                                        gc.ball.transform.position.z), 
                                                        0.5f));
    }

    private void FixedUpdate()
    {
        if (hasTarget)
        {
            // moveTo returns true when arrives, otherwise false, therefore if arrives, hasTarget is false and vise-versa
            hasTarget = !MoveTo(moveTarget);
        }
        else if (cg.GetTeamWithBall() != this.team)
        {
            //SetNewTarget(gc.ball.transform.position);
        }
    }

    void SetUpStats()
    {
        health = Random.Range(0.5f,1f);
        energy = Random.Range(0.5f, 1f);
        stamina = Random.Range(0.5f, 1f);
        strength = Random.Range(0.5f, 1f);
        speed = Random.Range(0.5f, 1f);
    }

    void SetUpStatesWeights()
    {
        traitWeights = new float[numTraits];

        for (int i = 0; i < traitWeights.Length; i++)
        {
            traitWeights[i] = Random.Range(0, 1f);
        }
    }

    void SetNewTarget(Vector3 tar)
    {
        moveTarget = tar;
        hasTarget = true;
    }

    // return true when arrive, otherwise false
    bool MoveTo(Vector3 moveTar)
    {
        float moveBuffer = 0.1f;
        Vector3 moveVector = moveTar - this.transform.position;

        if (moveVector.magnitude > moveBuffer)
        {
            this.transform.position += moveVector.normalized * speed * Time.deltaTime;
        }
        else
        {
            this.transform.position = moveTar;
            // return true for arrived
            Debug.Log("Arrived at : " + moveTar);
            return true;
        }
        return false;
    }

    void AssignTeamColour()
    {
        if (team == "A")
            GetComponentInChildren<SpriteRenderer>().material = materials[0];
        else if (team == "B")
            GetComponentInChildren<SpriteRenderer>().material = materials[1];
    }

    void AttackClosestEnemy()
    {
        FindClosest("enemy");
    }
    Player FindClosest(string team)
    {
        Player closest = null;
        float dist = float.PositiveInfinity;
        if (team == "friend")
        {
            foreach (Player p in friends)
            {
                float currDist = (p.transform.position - this.transform.position).magnitude;
                if (currDist < dist)
                {
                    dist = currDist;
                    closest = p;
                }
            }
        } else if (team == "enemy")
        {
            foreach (Player p in friends)
            {
                float currDist = (p.transform.position - this.transform.position).magnitude;
                if (currDist < dist)
                {
                    dist = currDist;
                    closest = p;
                }
            }
        } else
        {
            Debug.LogError("FindClosest must be passed either \"friend\" or \"enemy\"");
        }
        if (closest == null)
            Debug.LogError(team + " player not found");
        return closest;
    }
    void HelpClosestFriend()
    {
        FindClosest("friend");
    }
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
