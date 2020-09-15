using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
                    
public enum States {START,GAME,PAUSE,PLAY,BACK_MENU,GAME_OVER,EXIT}

public class GameState : MonoBehaviour
{
    public static GameState gamestate;

    public static GameState instance;
    public States currentState;

    public delegate void GameEvent();
    public GameEvent game;
    public delegate void PauseEvent();
    public PauseEvent pause;
    public delegate void PlayEvent();
    public PlayEvent play;
    public delegate void BackMenuEvent();
    public BackMenuEvent backmenu;
    public delegate void GameOverEvent();
    public GameOverEvent gameOver;
    public delegate void ExitEvent();
    public ExitEvent exitGame;

    void Awake()
    {
        if(gamestate == null)
        {
            gamestate = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    void Start ()
    {
        instance = this;
        currentState = States.START;

        game += Game;
        pause += Pause;
        play += Play;
        backmenu += BackMenu;
        gameOver += GameOver;
        exitGame += ExitGame;
	}
	
    public void ChangeState(States newState)
    {
        currentState = newState;

        switch(currentState)
        {
            case States.GAME:
                game();
                break;

            case States.PLAY:
                play();
                break;

            case States.BACK_MENU:
                backmenu();
                break;

            case States.GAME_OVER:
                gameOver();
                break;

            case States.EXIT:
                exitGame();
                break;
        }
    }
    
	public void Game()
    {
        Time.timeScale = 1;
        
        Loader.instance.LoadScene(2);
		SceneManager.LoadScene (2);

        StartCoroutine(Wait());

        UIController.instance.InitValues();
        PlayerProfile.instace.InitValue();
        UIController.instance.Hud();
    }

    public void Pause()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);

        Time.timeScale = 0;

        UIController.instance.menuPanel.SetActive(false);
        UIController.instance.hudPanel.SetActive(true);
        UIController.instance.pausePanel.SetActive(true);
        UIController.instance.outfitPanel.SetActive(false);
        UIController.instance.tutoPanel.SetActive(false);
        UIController.instance.rulePanel.SetActive(false);
        UIController.instance.ccRulePanel.SetActive(false);
        UIController.instance.gameoverPanel.SetActive(false);
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    public void BackMenu()
    {
        Time.timeScale = 1;

        Loader.instance.LoadScene(1);
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        UIController.instance.GameOver();
    }

    public void ExitGame()
    {
        SFXManeger.instance.PlaySFX(SFXType.EXIT);
        Application.Quit();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
