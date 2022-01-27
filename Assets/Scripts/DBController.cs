using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DBController : MonoBehaviour
{


    public static string leaderBoard = "";


    
    public void LoadLeaderBoardButton()
    {
        
        StartCoroutine(LoadScores());
    }


    public void SaveScoreButton()
    {

        StartCoroutine(SaveScore(StaticVariables.name,StaticVariables.PlayerScore));

    }


    
    private static bool fixer = true;

    public IEnumerator SaveScore(string userName, int score)
    {

        

        // Creating Post requst
        WWWForm form = new WWWForm();
        form.AddField("unity", "Save_Score");
        form.AddField("userName", userName);
        form.AddField("score", score);

        // request is sending
        if (fixer)
        {
            fixer = false;
            using (UnityWebRequest www = UnityWebRequest.Post("ozantekce.com/UnityDB.php", form))
            {
                print("hi");
                yield return www.SendWebRequest();


                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    //Debug.Log("\n"+www.downloadHandler.text);
                }

            }

            IEnumerator coroutine = WaitAndLoad(0.1f);
            StartCoroutine(coroutine);

        }


    }


    public IEnumerator LoadScores()
    {
        // Creating Post requst
        WWWForm form = new WWWForm();
        form.AddField("unity", "Load_Scores");
        // request is sending
        using (UnityWebRequest www = UnityWebRequest.Post("ozantekce.com/UnityDB.php", form))
        {

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string data = www.downloadHandler.text;
                data = data.Replace("|", "\t");
                data = data.Replace("*", "\n");
                //Debug.Log("\n" + data);
                leaderBoard = data;

            }

        }


    }



    private IEnumerator WaitAndLoad(float wait)
    {   

        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(CONSTANTS.MAINMENU_SCENE_INDEX);
        fixer = true;

    }



}
