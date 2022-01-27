using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public DBController DB;

    public GameObject mainMenu;
    public GameObject options;
    public GameObject leaderboard;
        public TMP_Text leaderboardLabel;
    public Slider sound;


    // set sound value with static value in HUD
    private void Start()
    {
        sound.value = StaticVariables.Sound;
    }


    // Leaderboard açýk ise günceller 
    float wait = 0;
    private void Update()
    {

        wait += Time.deltaTime;

        if (leaderboardLabel.text == "" || (wait > 0.7f && leaderboard.active))
        {

            DB.LoadLeaderBoardButton();
            leaderboardLabel.text = DBController.leaderBoard;
            wait = 0;
        }
            


    }



    // Load info scene then info scene load level 1
    public void StartGame() {


        StaticVariables.PlayerCurrentHP = 3;
        StaticVariables.PlayerScore = 0;
        InfoScene.InfoText = "Level 1";
        InfoScene.NextSceneIndex = 1;
        InfoScene.WaitTime = 1.5f;

        IEnumerator coroutine = WaitAndLoad(0.4f, CONSTANTS.INFO_SCENE_INDEX);
        StartCoroutine(coroutine);


    }

    private IEnumerator WaitAndLoad(float wait,int next)
    {
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(next);
    }

    public void ExitGame() {

        Application.Quit();

    }


    public void Apply() {

        options.SetActive(false);
        leaderboard.SetActive(false);
        mainMenu.SetActive(true);
        
    }
    
    public void Options()
    {

        options.SetActive(true);
        mainMenu.SetActive(false);

    }

    public void LeaderBoardButton()
    {

        leaderboard.SetActive(true);
        mainMenu.SetActive(false);
        DB.LoadLeaderBoardButton();

    }

    public static void SetSound(Slider slider)
    {

        StaticVariables.Sound = slider.value;

    }
    



}
