using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameState gameState;

    private void Awake()
    {
        gameState = GameState.Playing;
    }

    public void SetState(GameState gameState)
    {

    }

    public enum GameState
    {
        Playing,
        Won,
        Lost
    }
}
