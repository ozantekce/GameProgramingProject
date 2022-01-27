using UnityEngine.UI;

public static class StaticVariables
{


    public static string name;
    
    private static int playerCurrentHP = 3;
    private static int playerScore=0;
    private static float sound=0.5f;

    public static int PlayerCurrentHP { get => playerCurrentHP; set => playerCurrentHP = value; }
    public static int PlayerScore { get => playerScore; set => playerScore = value; }
    public static float Sound { get => sound; set {  sound = value; Music.GETMUSIC().UpdateVolume(); } }


    public static void ChangeHp(int val)
    {

        if(val>=3)
            playerCurrentHP = 3;
        else
            playerCurrentHP = val;

        PlayerDamageability.ChangeHp = true;

    }

    public static void IncreaseScore(int score)
    {

        playerScore += score;
        HUD.GETHUD().UpdateScore();
    }


}
