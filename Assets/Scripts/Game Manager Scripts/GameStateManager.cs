using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    GameManagerBaseState CurrentState;
    GameInProgressState GameInProgress = new GameInProgressState();
    GameOverState GameOver = new GameOverState();
    // Start is called before the first frame update
    void Start()
    {
        CurrentState = GameInProgress;
        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.EnterState(this);
    }
}
