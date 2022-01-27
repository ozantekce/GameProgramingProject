using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SendScore : MonoBehaviour
{

    public InputField name;
    public TMP_Text scoreLabel;

    

    private void Start()
    {
        scoreLabel.text = StaticVariables.PlayerScore.ToString();
        name.text = StaticVariables.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ChangeName()
    {
        StaticVariables.name = name.text;
    }

}
