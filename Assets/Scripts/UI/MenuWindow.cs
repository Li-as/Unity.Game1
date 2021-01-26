using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWindow : MonoBehaviour
{
    [SerializeField] private CreditsPanel _creditsPanel;
    [SerializeField] private string _firstLevelSceneName;

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(_firstLevelSceneName);
    }
    public void OnCreditsButtonClick()
    {
        _creditsPanel.Open();
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
