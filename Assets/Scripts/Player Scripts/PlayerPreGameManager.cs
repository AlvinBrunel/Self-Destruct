using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreGameManager : MonoBehaviour
{
    PlayerPreGameBaseState CurrentState;

    PlayerPreGameFallingState FallingState = new PlayerPreGameFallingState();
    PlayerPreGameFellState FellState = new PlayerPreGameFellState();
    PlayerPreGameGettingUpState GettingUpState = new PlayerPreGameGettingUpState();
    PlayerPreGameIdleState IdleState = new PlayerPreGameIdleState();


    // Start is called before the first frame update
    void Start()
    {
        CurrentState = FallingState;
        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.EnterState(this);
    }
}
