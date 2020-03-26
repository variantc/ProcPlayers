using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player playerPrefab;
    public Ball ballPrefab;
    public Ball ball;

    public Player[] players;
    List<Player> teamA;
    List<Player> teamB;
    
    [SerializeField]
    int numPlayersPerTeam = 1;


    private void Start()
    {
        ball = Instantiate(ballPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        teamA = new List<Player>();
        teamB = new List<Player>();

        // Spawn players and assign them to teamA or teamB
        SpawnPlayers(numPlayersPerTeam);
    
        players = FindObjectsOfType<Player>();

    }

    public List<Player> GetTeam(string team)
    {
        if (team == "A")
        {
            if (teamA != null)
                return teamA;
            else
            {
                Debug.LogError("No teamA");
                return null;
            }
        }
        else if (team == "B")
            if (teamB != null)
                return teamB;
            else
            {
                Debug.LogError("No teamB");
                return null;
            }
        else
        {
            Debug.LogError("Incorrect team requested");
            return null;
        }
    }

    void SpawnPlayers(int numPlayers)
    {
        for (int i = 0; i < numPlayers; i++)
        {
            teamA.Add(Instantiate(playerPrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f), Quaternion.identity));
            teamA[teamA.Count - 1].Team = "A";
            teamA[teamA.Count - 1].transform.name = "A_" + i;
            teamB.Add(Instantiate(playerPrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f), Quaternion.identity));
            teamB[teamB.Count - 1].Team = "B";
            teamB[teamB.Count - 1].transform.name = "B_" + i;
        }
    }
}
