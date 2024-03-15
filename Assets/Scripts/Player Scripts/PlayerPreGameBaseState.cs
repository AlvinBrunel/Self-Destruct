using UnityEngine;

public abstract class PlayerPreGameBaseState
{
    public abstract void EnterState(PlayerPreGameManager PlayerPreGameManager);

    public abstract void UpdateState(PlayerPreGameManager PlayerPreGameManager);

    public abstract void OnCollisionEnter(PlayerPreGameManager PlayerPreGameManager);

}
