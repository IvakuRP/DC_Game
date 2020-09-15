using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static Loader instance;
    public Text loaderText;
    public GameObject loaderPanel;
    AsyncOperation loaderScene;    
    bool loading;

    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
        loading = false;
        loaderPanel.SetActive(false);
    }

    void Start ()
    {
        LoadScene(1);
	}
	
	void Update ()
    {
        if (loading)
        {
            loaderText.text = "Cargando ...";  /*+ loaderScene.progress.ToString()*/
            if (loaderScene.isDone)
                loaderPanel.SetActive(false);
        }
	}

    public void LoadScene(int numscene) //Pasar el valor de la escena a cargar
    {
        loaderPanel.SetActive(true);
        loading = true;
        loaderScene = SceneManager.LoadSceneAsync(numscene);
        loading = true;
    }


}
