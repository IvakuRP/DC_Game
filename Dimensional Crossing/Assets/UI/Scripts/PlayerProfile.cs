using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerProfile : MonoBehaviour {

    public static PlayerProfile instace;
    public int maxScore;
    public int total;
    public int score;
    public int ccCount;
    public int covySelected;

    public int firstGame;

    private StreamReader sr;
    private StreamWriter sw;
    private string line;
    private string[] tmpData;
    private char[] delimeterChars = {'|'};

    void Start (){
        instace = this;
        firstGame = 0;
        InitValue();
        LoadData();
    }

    private void Update()
    {
        NewMaxScore();
    }

    public void InitValue()
    {
        score = 0;
        ccCount = 0;
    }

    public void StartGame()
    {
        firstGame = 1;
        SaveData();
    }

    public void AddCoin()
    {
        ccCount++;
        UIController.instance.SetCoin(coin: ccCount);
    }

    public void AddScore(int value)
    {
        score = score + value;
        UIController.instance.SetScore(score: score);
    }

    public void CharacterSelection(int character)
    {
        covySelected = character;
        SaveData();
    }

    public void NewMaxScore()
    {
        total = score + (ccCount * 30);

        if (total > maxScore)
        {
            maxScore = total;
            UIController.instance.SetMaxScore(maxScore);
            SaveData();
        }
        else
            UIController.instance.SetMaxScore(maxScore);
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            sr = new StreamReader(Application.persistentDataPath + "/PlayerData.dat");
            while ((line = sr.ReadLine()) != null)
            {
                tmpData = line.Split(delimeterChars);
                firstGame = int.Parse(tmpData[0]);
                covySelected = int.Parse(tmpData[1]);
                maxScore = int.Parse(tmpData[2]);
            }
            sr.Close();
        }
    }

    public void SaveData()
    {
        line = firstGame + "|" + covySelected + '|' + maxScore;
        sw = new StreamWriter(Application.persistentDataPath + "/PlayerData.dat", false);

        sw.WriteLine(line);
        sw.Close();
    }
}
