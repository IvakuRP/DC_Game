using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //Quitar si no es necesario

public class UIController : MonoBehaviour {

    public static UIController instance;

    public GameObject menuPanel;
    public GameObject hudPanel;
    public GameObject pausePanel;
    public GameObject outfitPanel;
    public GameObject tutoPanel;
    public GameObject rulePanel;
    public GameObject ccRulePanel;
    public GameObject gameoverPanel;

    public Text maxScoreText;
    public Text scoreText;
    public Text covycoinsText;

    public Image covyImage;
    public Image covynameImage;

    public Sprite[] covyImages;
    public Sprite[] covynameImages;
    public int arrayMax = 5;
    public int arrayMin = 0;
    public int pivot;
    public Button previous;
    public Button next;

    public Text scoreGOText;
    public Text covycoinsGOText;

	void Start () {
        instance = this;

        menuPanel.SetActive(true);
        hudPanel.SetActive(false);
        pausePanel.SetActive(false);
        outfitPanel.SetActive(false);
        tutoPanel.SetActive(false);
        rulePanel.SetActive(false);
        ccRulePanel.SetActive(false);
        gameoverPanel.SetActive(false);

        covycoinsText.text = "0x";

        pivot = 0;

        covyImage.sprite = covyImages[pivot];
        covynameImage.sprite = covynameImages[pivot];

        scoreGOText.text = "0";
        covycoinsGOText.text = "0";
}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameState.instance.ChangeState(States.EXIT);

        covyImage.sprite = covyImages[pivot];
        covynameImage.sprite = covynameImages[pivot];

        if (pivot == arrayMax)
            next.interactable = false;
        else
            next.interactable = true;

        if (pivot == arrayMin)
            previous.interactable = false;
        else
            previous.interactable = true;
    }

    public void SetCoin(int coin)
    {
        covycoinsText.text = coin.ToString() + "x";
        covycoinsGOText.text = coin.ToString();
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
        scoreGOText.text = score.ToString();
    }

    public void InitValues()
    {
        scoreText.text = "0";
        covycoinsText.text = "0x";

        scoreGOText.text = "0";
        covycoinsGOText.text = "0";
    }

    public void StartGame()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);

        if (PlayerProfile.instace.firstGame == 1){
            GameState.instance.ChangeState(States.GAME);
        }
        else{
            GameState.instance.ChangeState(States.GAME);

            Time.timeScale = 0;

            menuPanel.SetActive(false);
            tutoPanel.SetActive(true);
            rulePanel.SetActive(true);
        }
    }

    public void ReStart()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);

        GameState.instance.ChangeState(States.GAME);
    }

    public void Hud()
    {
        menuPanel.SetActive(false);
        hudPanel.SetActive(true);
        pausePanel.SetActive(false);
        outfitPanel.SetActive(false);
        tutoPanel.SetActive(false);
        rulePanel.SetActive(false);
        ccRulePanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void Outfit()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);

        menuPanel.SetActive(false);
        hudPanel.SetActive(false);
        pausePanel.SetActive(false);
        outfitPanel.SetActive(true);
        tutoPanel.SetActive(false);
        rulePanel.SetActive(false);
        ccRulePanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void Continue()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);

        menuPanel.SetActive(false);
        hudPanel.SetActive(true);
        pausePanel.SetActive(false);
        outfitPanel.SetActive(false);
        tutoPanel.SetActive(false);
        rulePanel.SetActive(false);
        ccRulePanel.SetActive(false);
        gameoverPanel.SetActive(false);

        GameState.instance.ChangeState(States.PLAY);
    }

    public void BackMenu()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);
        GameState.instance.ChangeState(States.BACK_MENU);

        menuPanel.SetActive(true);
        hudPanel.SetActive(false);
        pausePanel.SetActive(false);
        outfitPanel.SetActive(false);
        tutoPanel.SetActive(false);
        rulePanel.SetActive(false);
        ccRulePanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void NextCovy()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);
        pivot++;
    }

    public void PreviousCovy()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);
        pivot--;
    }

    public void SelectCovy()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);

        PlayerProfile.instace.CharacterSelection(pivot);

        menuPanel.SetActive(true);
        hudPanel.SetActive(false);
        pausePanel.SetActive(false);
        outfitPanel.SetActive(false);
        tutoPanel.SetActive(false);
        rulePanel.SetActive(false);
        ccRulePanel.SetActive(false);
        gameoverPanel.SetActive(false);

    }

    public void Tuto()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);
        tutoPanel.SetActive(true);
        rulePanel.SetActive(false);
        ccRulePanel.SetActive(true);
    }

    public void DisableTuto()
    {
        SFXManeger.instance.PlaySFX(SFXType.BUTTON);
        PlayerProfile.instace.StartGame();

        tutoPanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void GameOver()
    {
        menuPanel.SetActive(false);
        hudPanel.SetActive(false);
        pausePanel.SetActive(false);
        outfitPanel.SetActive(false);
        tutoPanel.SetActive(false);
        rulePanel.SetActive(false);
        ccRulePanel.SetActive(false);
        gameoverPanel.SetActive(true);
    }

    public void SetMaxScore(int maxscore)
    {
        maxScoreText.text = maxscore.ToString();
    }

    public void Exit()
    {
        GameState.instance.ChangeState(States.EXIT);
    }
}
