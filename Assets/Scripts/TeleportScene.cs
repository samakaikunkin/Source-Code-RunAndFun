using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScene : MonoBehaviour
{
    public int StartGame;
    public int GameOver;
    public int FinishGame;

    public void StartGameButton(){

        SceneManager.LoadScene(StartGame);
    }

    public void GameOverButton(){
        SceneManager.LoadScene(GameOver);
    }

    public void FinishGameButton(){
        SceneManager.LoadScene(GameOver);
    }
}
