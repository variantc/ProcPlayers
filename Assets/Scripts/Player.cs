using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    GameController game;
    ConditionsOfGame condition;
    PlayerActions actions;
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

    int numActions = 2;
    [SerializeField]
    List<int> actionChoiceList;
    int[] actionChoiceArray;

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
        game = FindObjectOfType<GameController>();
        condition = FindObjectOfType<ConditionsOfGame>();
        actions = FindObjectOfType<PlayerActions>();
        
        actionChoiceList = new List<int>();
        SetUpChoiceArray();

        
        AssignTeamColour();

        numTraits = System.Enum.GetNames(typeof(Refs.BehavState)).Length;

        // Set up stats and state weights with random values
        SetUpStats();
        SetUpStatesWeights();

        // set initial random target
        //SetNewTarget(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f));

        SetNewTarget(Refs.FindFractionalPointBetween(game.ball.transform.position, 
                                                        new Vector3(
                                                        game.ball.transform.position.x,
                                                        Refs.ARENA_HEIGHT/2,
                                                        game.ball.transform.position.z), 
                                                        0.5f));
    }

    private void FixedUpdate()
    {
        int currentAction = -1;

        // we want to check the game conditions each physics cycle
        switch (condition.GetBallLocation())
        {
            case "BottomLeft":
            case "BottomCentre":
            case "BottomRight":
            case "MiddleLeft":
            case "MiddleCentre":
                currentAction = actionChoiceArray[0];
                break;
            case "MiddleRight":
            case "TopLeft":
            case "TopCentre":
            case "TopRight":
                currentAction = actionChoiceArray[1];
                break;
            default:
                Debug.LogError("Player: ball location switch made it to default");
                break;
        }

        Debug.Log(this.transform.name + ": " + currentAction);

        switch (currentAction)
        {
            case 0:
                hasTarget = !actions.MoveTo(this, moveTarget, speed);
                break;
            case 1:
                actions.ThrowBall(game.ball, moveTarget);
                break;
            default:
                Debug.LogError("Player: current action switch made it to default - is current action not set");
                break;

        }

        //if (hasTarget)
        //{
        //    // moveTo returns true when arrives, otherwise false, therefore if arrives, hasTarget is false and vise-versa
        //    hasTarget = !actions.MoveTo(this, moveTarget, speed);
        //}
        //else if (condition.GetTeamWithBall() != this.team)
        //{
        //    //SetNewTarget(gc.ball.transform.position);
        //}
    }

    void SetUpChoiceArray()
    {
        // initialise list with ordered numbers
        int n = numActions;
        for (int i = 0; i < numActions; i++)
        {
            actionChoiceList.Add(i);
        }
        
        // shuffle list order
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = actionChoiceList[k];
            actionChoiceList[k] = actionChoiceList[n];
            actionChoiceList[n] = temp;
        }

        actionChoiceArray = actionChoiceList.ToArray();
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
    
    void AssignTeamColour()
    {
        if (team == "A")
            GetComponentInChildren<SpriteRenderer>().material = materials[0];
        else if (team == "B")
            GetComponentInChildren<SpriteRenderer>().material = materials[1];
    }

    
}
