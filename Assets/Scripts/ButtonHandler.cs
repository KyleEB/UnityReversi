using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void SetDifficulty(int difficulty)
    {
        PlayController.minimaxDepth = difficulty;   
    }

    public void SetPlayerPieceColor(string color)
    {
        PlayController.humanPiece = color;   
    }

    public void StartReversi()
    {
        SceneManager.LoadScene("Reversi", LoadSceneMode.Single);
    }
}
