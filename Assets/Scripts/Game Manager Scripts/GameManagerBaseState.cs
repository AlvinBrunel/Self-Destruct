using UnityEngine;

public abstract class GameManagerBaseState
{
    public abstract void EnterState(GameStateManager GameManager);

    public abstract void UpdateState(GameStateManager GameManager);

}
