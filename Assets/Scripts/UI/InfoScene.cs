using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoScene : MonoBehaviour
{


    private static string infoText; // text in the screen
    private static int nextSceneIndex;      // the index of screen that will load
    private static float waitTime;  // the time this screen is visibles

    public static string InfoText { get => infoText; set => infoText = value; }

    public static float WaitTime { get => waitTime; set => waitTime = value; }
    public static int NextSceneIndex { get => nextSceneIndex; set => nextSceneIndex = value; }

    IEnumerator Start()
    {


        TMP_Text infoLabel = GetComponentInChildren<TMP_Text>();
        infoLabel.text = infoText;
        
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(nextSceneIndex);


    }




}
