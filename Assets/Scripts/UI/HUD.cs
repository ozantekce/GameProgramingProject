using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{


    public  Image hpBarBase;

    public  GameObject popUpMenu;
        public GameObject settings;
            public Slider sound;
        public GameObject menu;

    public  GameObject popUpMenuDied;

    public  TMP_Text timeLabel;
    public  TMP_Text scoreLabel;



    public  int timeOut=60;
    private int currentTime=0;

    // Store last time of change timelabel
    private float lastTimeOfIncreaseSec;



    private void Start()
    {


        popUpMenu.SetActive(false);
        popUpMenuDied.SetActive(false);
        settings.SetActive(false);
        menu.SetActive(false);

        timeLabel.text  = timeOut.ToString();
        scoreLabel.text = StaticVariables.PlayerScore.ToString();



        lastTimeOfIncreaseSec = Time.realtimeSinceStartup;

        sound.value = StaticVariables.Sound;
        
    }


    private void FixedUpdate()
    {


        // If the time is over, the player dies
        if (ControlMaxTime())
        {
            if (StaticVariables.PlayerCurrentHP != 0)
            {

                StaticVariables.ChangeHp(0);
            }
                

        }
        else
        {
            UpdateTime();
        }
        
    }

    

    // Update time label with Time.realtimeSinceStartup - startTime if reaches next int value
    private void UpdateTime()
    {
        
        float time = Time.realtimeSinceStartup - lastTimeOfIncreaseSec;
        
        if (time >= 1)
        {

            currentTime++;
            timeLabel.text = (timeOut-currentTime).ToString();
            lastTimeOfIncreaseSec = Time.realtimeSinceStartup;
        }
        


    }

    // Increase score with parameter and update scoreLabel
    public void UpdateScore()
    {

        scoreLabel.text = StaticVariables.PlayerScore.ToString();
        
    }

    // Set score with parameter and update scoreLabel
    public void SetScore(int score)
    {

        StaticVariables.PlayerScore = score;
        scoreLabel.text = StaticVariables.PlayerScore.ToString();

    }

    // Control time
    private bool ControlMaxTime()
    {
        return timeOut <= currentTime;
    } 



    // Load MainMenu Sceen
    public void MainMenu()
    {
        Time.timeScale = 1;
        IEnumerator coroutine = CONSTANTS.WaitAndLoad(0.4f, CONSTANTS.MAINMENU_SCENE_INDEX);
        StartCoroutine(coroutine);
    }

    // Resume Current Sceen
    public void Resume()
    {

        popUpMenu.SetActive(false);
        Time.timeScale = 1;
        
    }

    // Restart Current Sceen
    public void Restart()
    {

        currentTime = 0;
        StaticVariables.PlayerCurrentHP = 3;
        StaticVariables.PlayerScore = 0;
        Time.timeScale = 1;
        IEnumerator coroutine = CONSTANTS.WaitAndLoad(0.4f, SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(coroutine);
    }


    // Set visible Settings and hide Menu
    public void Setting()
    {

        settings.SetActive(true);
        menu.SetActive(false);
        
    }

    // Set visible Menu and hide Settings
    public void Apply()
    {

        settings.SetActive(false);
        menu.SetActive(true);

    }

    // When esc is pressed, If PopUpMenu is active , resume game else set PopUpMenu is visible
    public void PopUpMenuControl()
    {

        popUpMenu.SetActive(!popUpMenu.activeInHierarchy);
        menu.SetActive(true);
        settings.SetActive(false);

        if (popUpMenu.activeInHierarchy)
        {
            Time.timeScale = 0;
        }   
        else
        {
            Time.timeScale = 1;
           
        }
        

    }


    // Update hpbar with max and current hp
    public void UpdateHpBar(Damageability damageability)
    {

        int pixels = 32;
        int width = pixels * damageability.MaxHp;
        hpBarBase.rectTransform.sizeDelta = new Vector2(width, 32);

        width = pixels * damageability.CurrentHp;
        Image hpBar = hpBarBase.GetComponentsInChildren<Image>()[1];
        hpBar.rectTransform.sizeDelta = new Vector2(width, 32);

        
    }


    // Sound set with slider.value
    public static void Sound(Slider slider)
    {
        
        StaticVariables.Sound = slider.value;

    }



    private static HUD hud;

    public static HUD GETHUD()
    {
        if (hud != null)
            return hud;
        GameObject hudGameObject = GameObject.Find("HUD"); 
        return hudGameObject.GetComponent<HUD>();

    }





}
