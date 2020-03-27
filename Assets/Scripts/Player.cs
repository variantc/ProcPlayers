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

    int numActions = 9;
    List<int> actionChoiceList;
    [SerializeField]
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
        
        //actionChoiceList = new List<int>();
        SetUpChoiceArray();
        
        AssignTeamColour();

        numTraits = System.Enum.GetNames(typeof(Refs.BehavState)).Length;

        // Set up stats and state weights with random values
        SetUpStats();
        SetUpStatesWeights();

        // set initial random target
        //SetNewTarget(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f));

    }

    private void FixedUpdate()
    {
        int currentAction = -1;

        // we want to check the game conditions each physics cycle?

        // ---------------------------------------------------------------------------------------
        // NOBODY HAS BALL
        // ---------------------------------------------------------------------------------------
        if (condition.GetTeamWithBall() == "None")
        {
            currentAction = LocationConditions(0, 1, 2);
        }

        // ---------------------------------------------------------------------------------------
        // PLAYER'S TEAM HAS BALL
        // ---------------------------------------------------------------------------------------
        if (condition.GetTeamWithBall() == team)
        {
            currentAction = LocationConditions(3, 4, 5);
        }

        // ---------------------------------------------------------------------------------------
        // ENEMY TEAM HAS BALL
        // ---------------------------------------------------------------------------------------
        else
        {
            currentAction = LocationConditions(6, 7, 8);
        }
        
        Debug.Log(this.transform.name + ": " + currentAction);

        switch (currentAction)
        {
            case 0:
                // move between ball and top goal line
                SetNewTarget(Refs.FindFractionalPointBetween(game.ball.transform.position,
                                                                new Vector3(
                                                                game.ball.transform.position.x,
                                                                Refs.ARENA_HEIGHT / 2,
                                                                game.ball.transform.position.z),
                                                                traitWeights[0]));
                hasTarget = !actions.MoveTo(this, moveTarget, speed);
                break;
            case 1:
                // move between ball and bottom goal line
                SetNewTarget(Refs.FindFractionalPointBetween(game.ball.transform.position,
                                                                new Vector3(
                                                                game.ball.transform.position.x,
                                                                -Refs.ARENA_HEIGHT / 2,
                                                                game.ball.transform.position.z),
                                                                traitWeights[1]));
                hasTarget = !actions.MoveTo(this, moveTarget, speed);
                break;
            case 2:
                // move to ball
                hasTarget = !actions.MoveTo(this, game.ball.transform.position, speed);
                break;
            case 3:
                actions.ThrowBall(game.ball, moveTarget);
                break;
            case 4:
                // move between ball and right line
                SetNewTarget(Refs.FindFractionalPointBetween(game.ball.transform.position,
                                                                new Vector3(
                                                                Refs.ARENA_WIDTH / 2,
                                                                game.ball.transform.position.y,
                                                                game.ball.transform.position.z),
                                                                traitWeights[2]));
                hasTarget = !actions.MoveTo(this, moveTarget, speed);
                break;
            case 5:
                // move between ball and left line
                SetNewTarget(Refs.FindFractionalPointBetween(game.ball.transform.position,
                                                                new Vector3(
                                                                -Refs.ARENA_WIDTH / 2,
                                                                game.ball.transform.position.y,
                                                                game.ball.transform.position.z),
                                                                traitWeights[3]));
                hasTarget = !actions.MoveTo(this, moveTarget, speed);
                break;
            case 6:
            case 7:
            case 8:
            case 9:
                break;
            default:
                Debug.LogError("Player: current action switch made it to default - is current action not set");
                break;
        }
    }

    int LocationConditions(int a, int b, int c)
    {
        int choice = -1;
        switch (condition.GetBallLocation())
        {
            case "BottomLeft":
            case "BottomCentre":
            case "BottomRight":
                choice = actionChoiceArray[a];
                break;
            case "MiddleLeft":
            case "MiddleCentre":
            case "MiddleRight":
                choice = actionChoiceArray[b];
                break;
            case "TopLeft":
            case "TopCentre":
            case "TopRight":
                choice = actionChoiceArray[c];
                break;
            default:
                Debug.LogError("Player: ball location switch made it to default");
                break;
        }

        return choice;
    }

    void SetUpChoiceArray()
    {
        /// FOR RANDOM NON-REPEATING NUMBERS:

        //// initialise list with ordered numbers
        //int n = numActions;
        //for (int i = 0; i < numActions; i++)
        //{
        //    actionChoiceList.Add(i);
        //}

        //// shuffle list order
        //while (n > 1)
        //{
        //    n--;
        //    int k = Random.Range(0, n + 1);
        //    int temp = actionChoiceList[k];
        //    actionChoiceList[k] = actionChoiceList[n];
        //    actionChoiceList[n] = temp;
        //}

        //actionChoiceArray = actionChoiceList.ToArray();

        actionChoiceArray = new int[numActions];
        for (int i = 0; i < actionChoiceArray.Length; i++)
        {
            actionChoiceArray[i] = Random.Range(0, numActions);
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
    void AssignTeamColour()
    {
        if (team == "A")
            GetComponentInChildren<SpriteRenderer>().material = materials[0];
        else if (team == "B")
            GetComponentInChildren<SpriteRenderer>().material = materials[1];
    }
    
}
