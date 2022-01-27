using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{


    public AudioListener listener;

    private static AudioSource currentMusic;
    private static float maxVolumeOfCurrentMusic= 0f;
    private static float currentMusicTime = 0f;

    public AudioSource levelMusic;
    private float maxVolumeOflevelMusic = 0.3f;

    public AudioSource mainMenuMusic;
    private float maxVolumeOfmainMenuMusic = 0.5f;


    public GameObject buttonEffects;
    private float maxVolumeOfButtons = 0.1f;

    public GameObject effects;
    private float maxVolumeOfEffects = 0.4f;


    // Start is called before the first frame update
    void Start()
    {



        levelMusic.gameObject.SetActive(false);
        mainMenuMusic.gameObject.SetActive(false);


        if (SceneManager.GetActiveScene().buildIndex == CONSTANTS.INFO_SCENE_INDEX)
            return;

        if (SceneManager.GetActiveScene().buildIndex == CONSTANTS.MAINMENU_SCENE_INDEX)
        {
            mainMenuMusic.gameObject.SetActive(true);
            currentMusic = mainMenuMusic;
            maxVolumeOfCurrentMusic = maxVolumeOfmainMenuMusic;
        }
        else
        {
            levelMusic.gameObject.SetActive(true);
            currentMusic = levelMusic;
            maxVolumeOfCurrentMusic = maxVolumeOflevelMusic;
        }

        currentMusic.Play();
        UpdateVolume();

    }



    public void UpdateVolume()
    {
        if(currentMusic!=null)
            currentMusic.volume = StaticVariables.Sound * maxVolumeOfCurrentMusic;

    }

    private static Music music;

    public static Music GETMUSIC()
    {
        if (music != null)
            return music;
        GameObject hudGameObject = GameObject.Find("Music");
        return hudGameObject.GetComponent<Music>();

    }






    public void Confirm()
    {
        AudioSource [] temp = buttonEffects.GetComponentsInChildren<AudioSource>();
        temp[0].volume = StaticVariables.Sound*maxVolumeOfButtons;
        temp[0].Play();
    }

    public void Cancel()
    {
        AudioSource[] temp = buttonEffects.GetComponentsInChildren<AudioSource>();
        temp[1].volume = StaticVariables.Sound * maxVolumeOfButtons;
        temp[1].Play();
    }


    [MethodImpl(MethodImplOptions.Synchronized)]
    public void JumpEffect1(Vector2 source)
    {
        AudioSource[] temp = effects.GetComponentsInChildren<AudioSource>();
        temp[0].volume = StaticVariables.Sound * SoundDistanceCalculator(source)* maxVolumeOfEffects;
        temp[0].Play();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void HurtEffect1(Vector2 source)
    {
        AudioSource[] temp = effects.GetComponentsInChildren<AudioSource>();
        temp[1].volume = StaticVariables.Sound * SoundDistanceCalculator(source)* maxVolumeOfEffects;
        temp[1].Play();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void HurtEffect2(Vector2 source)
    {
        AudioSource[] temp = effects.GetComponentsInChildren<AudioSource>();
        temp[2].volume = StaticVariables.Sound * SoundDistanceCalculator(source) * maxVolumeOfEffects*2.7f;
        temp[2].Play();
    }

    public void WinEffect(Vector2 source)
    {
        AudioSource[] temp = effects.GetComponentsInChildren<AudioSource>();
        temp[3].volume = StaticVariables.Sound * SoundDistanceCalculator(source)*maxVolumeOfEffects;
        temp[3].Play();
        
    }

    public void LostEffect(Vector2 source)
    {

        AudioSource[] temp = effects.GetComponentsInChildren<AudioSource>();
        temp[4].volume = StaticVariables.Sound * 1*maxVolumeOfEffects;
        temp[4].Play();

    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void TakeItemEffect1(Vector2 source)
    {
        AudioSource[] temp = effects.GetComponentsInChildren<AudioSource>();
        temp[5].volume = StaticVariables.Sound * SoundDistanceCalculator(source) * maxVolumeOfEffects*0.5f;
        temp[5].Play();

    }


    private float minDistanceToListen = 5;

    private float SoundDistanceCalculator(Vector2 source)
    {

        float distance = Vector2.Distance(listener.transform.position, source);

        if (distance > minDistanceToListen)
            return 0;
        if (distance <= 0.3f)
            return 1;
        //LINEAR
        return 1 - (distance * 1 / minDistanceToListen);
        

    }


}
