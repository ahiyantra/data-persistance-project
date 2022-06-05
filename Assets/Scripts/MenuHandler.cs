using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public Text BestScore;
    public InputField iFi;
    //public ColorPicker ColorPicker;

    //public void NewColorSelected(Color color)
    //{
        // add code here to handle when a color is selected
        //NewMainManager.Instance.TeamColor = color;
    //}

    private void Start()
    {
        //ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        //ColorPicker.onColorChanged += NewColorSelected;

        //ColorPicker.SelectColor(NewMainManager.Instance.TeamColor);

        NewMainManager.Instance.LoadFile();
        BestScore.text = $"Best Score : {NewMainManager.Instance.hPlayerName} | {NewMainManager.Instance.h_Points}";
    }

    public void GameStart()
    {
        NewMainManager.Instance.nPlayerName = iFi.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        NewMainManager.Instance.SaveFile();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); // code to quit unity player
#else
        Application.Quit(); // code to quit game playing
#endif
    }

    public void SaveStuff()
    {
        NewMainManager.Instance.SaveFile();
    }

    public void LoadStuff()
    {
        NewMainManager.Instance.LoadFile();
        //ColorPicker.SelectColor(NewMainManager.Instance.TeamColor);
    }

    public void BackToMenu()
    {
        NewMainManager.Instance.SaveFile();
        SceneManager.LoadScene(0);
    }
}
