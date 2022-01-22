using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{ 
    //Menus
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject infoMenu;
    public GameObject loadingScreen;

    //Menu UI Elements
    private Button start, info, options, quit;//mainMenu
    private Button back;//infoMenu
    public Slider LoadingBar;

    //thnk about tommorow
    
    void Start()
    {       
        mainMenu.SetActive(true);

        start = mainMenu.transform.GetChild(0).GetComponent<Button>();
        options = mainMenu.transform.GetChild(1).GetComponent<Button>();
        info = mainMenu.transform.GetChild(2).GetComponent<Button>();
        quit = mainMenu.transform.GetChild(2).GetComponent<Button>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu.active) ChangeMenu(optionsMenu, mainMenu);
            if (infoMenu.active) ChangeMenu(infoMenu, mainMenu);
        }
    }

    public void ChangeMenu(GameObject current, GameObject next)
    {
        current.SetActive(false);
        next.SetActive(true);
    }

    public void optionsButton() { ChangeMenu(mainMenu, optionsMenu); }
    public void InfoButton() { ChangeMenu(mainMenu, infoMenu); }
    public void exitButton() { Application.Quit(); }
    public void backButton()
    {
        if (optionsMenu.active) ChangeMenu(optionsMenu, mainMenu);
        if (infoMenu.active) ChangeMenu(infoMenu, mainMenu);
    }

    public void StartAsync() { StartCoroutine(LoadAsync()); }
    IEnumerator LoadAsync()
    {
        AsyncOperation loadGame = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        ChangeMenu(mainMenu, loadingScreen);

        while (!loadGame.isDone)
        {
            float progress = Mathf.Clamp01(loadGame.progress / .9f);
            LoadingBar.value = progress;

            yield return null;
        }
    }
}