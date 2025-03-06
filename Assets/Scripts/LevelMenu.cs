using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{    
    public Button[] buttons;

    private void Awake()
    {
        Debug.Log("LevelMenu_Awake_ReachedIndex_Pre: " + PlayerPrefs.GetInt("ReachedIndex"));
        Debug.Log("LevelMenu_Awake_UnlockedLevel_Pre: " + PlayerPrefs.GetInt("UnlockedLevel"));

        PlayerPrefs.Save();
        int unlockedLevel;

        if (PlayerPrefs.GetInt("UnlockedLevel") == 0)
        {
            unlockedLevel = 1;
            PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel);
            PlayerPrefs.Save();
        }
        else
        {
            unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");
        }

        Debug.Log("LevelMenu_Awake_ReachedIndex_After: " + PlayerPrefs.GetInt("ReachedIndex"));
        Debug.Log("LevelMenu_Awake_UnlockedLevel_After: " + PlayerPrefs.GetInt("UnlockedLevel"));

        for (int i = 0; i < buttons.Length; i++) 
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
}
