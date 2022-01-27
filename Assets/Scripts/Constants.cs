using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CONSTANTS
{

    /* UI */

    public readonly static int SENDSCORE_SCENE_INDEX = SENDSCORE_SCENE();
    public readonly static int MAINMENU_SCENE_INDEX = 0;
    public readonly static int INFO_SCENE_INDEX = INFO_SCENE();

    /* end UI*/


    /*  Limitations  */

    public readonly static float MAX_SPEED = 10;

    /*  end Limitations  */


    /* Optimization */

    public readonly static Dictionary<int, Vector2> DIRECTIONS = GetDirections();

    /* end Optimization */


    /*  Layers  */

    public readonly static int GROUND_LAYER = 3;
    public readonly static int BOUND_LAYER = 6;
    public readonly static int GHOSTGROUND_LAYER = 7;
    public readonly static int ENEMY_LAYER = 8;
    public readonly static int ITEM_LAYER = 9;

    /*  end Layers  */


    /*  Tags  */

        //      player
    public readonly static string PLAYER_TAG = "Player";

        //      Enemies
    public readonly static string ANT_TAG = "Ant";
    public readonly static string GATOR_TAG = "Gator";
    public readonly static string GLASSHOPPER_TAG = "Glasshooper";

        //      Others
    public readonly static string GROUND_TAG = "Ground";
    public readonly static string CHANGEDIRECTION_TAG = "ChangeDirection";

        //      Items
    public readonly static string HEART_TAG = "Heart";
    public readonly static string ACORN_TAG = "Acorn";

    /*  end Tags  */




    /*  Scores  */

    public readonly static int ACORN_SCORE = 100;

    /* end Scores  */




    /*  Lists   */

    //      enemy Lists
    public readonly static ArrayList ENEMY_CHANGE_DIRECTION_LIST = GetEnemyChangeDirection();

    //      trap Lists
    public readonly static ArrayList BLADE_CHANGE_DIRECTION_LIST = GetBladeChangeDirection();

    //      player Lists
    public readonly static ArrayList PLAYER_GIVE_DAMAGE_LIST = GetPlayerGiveDamage();


    /*  end Lists   */



    // direction : 0-left   1-right     2-down  3-up 
    private static Dictionary<int, Vector2> GetDirections(){


        Dictionary<int, Vector2> temp = new Dictionary<int, Vector2>();

        temp.Add(0,new Vector2(-1,0));
        temp.Add(1, new Vector2(1, 0));
        temp.Add(2, new Vector2(0, -1));
        temp.Add(3, new Vector2(0, 1));


        return temp;

    }

    private static ArrayList GetEnemyChangeDirection()
    {
        if (ENEMY_CHANGE_DIRECTION_LIST != null)
            return ENEMY_CHANGE_DIRECTION_LIST;
        else {
            ArrayList temp = new ArrayList();
            //  adding layers
            temp.Add(GROUND_LAYER);
            temp.Add(ENEMY_LAYER);
            //  adding tags
            temp.Add(CHANGEDIRECTION_TAG);
            temp.Add(PLAYER_TAG);
            return temp;
        }

    }


    private static ArrayList GetBladeChangeDirection()
    {
        if (BLADE_CHANGE_DIRECTION_LIST != null)
            return BLADE_CHANGE_DIRECTION_LIST;
        else
        {
            ArrayList temp = new ArrayList();
            //  adding tags
            temp.Add(GROUND_TAG);
            temp.Add(CHANGEDIRECTION_TAG);

            return temp;
        }

    }


    private static ArrayList GetPlayerGiveDamage()
    {
        if (PLAYER_GIVE_DAMAGE_LIST != null)
            return PLAYER_GIVE_DAMAGE_LIST;
        else
        {
            ArrayList temp = new ArrayList();
            // adding layers
            temp.Add(ENEMY_LAYER);
            return temp;
        }
    }


    // compares two lists
    // if list has any value in list2 true otherwise false
    public static bool ContainsList(ArrayList list,ArrayList list2)
    {

        for(int i = 0; i < list2.Count; i++)
        {

            if (list.Contains(list2[i]))
                return true;

        }

        return false;

    }

    
    private static int INFO_SCENE()
    {
        return SceneManager.sceneCountInBuildSettings - 2;
    }

    private static int SENDSCORE_SCENE()
    {
        return SceneManager.sceneCountInBuildSettings - 1;
    }

    public static IEnumerator WaitAndLoad(float wait, int next)
    {
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(next);
    }
}