using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
public class MenuUIHandler : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HighscoreMenu;
    public TextMeshProUGUI ScoreText;

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitApplication()
    {
        DataManager.Instance.SaveHighscore();
        if (UnityEditor.EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }

    public void GetName(string name)
    {
        DataManager.Instance.ScoreName = name;
    }

    public void GetHighscore()
    {
        DataManager.Instance.LoadHighscore();
        MainMenu.SetActive(false);
        HighscoreMenu.SetActive(true);
        ScoreText.text = $"{DataManager.Instance.Highscore} by {DataManager.Instance.HighscoreName}";
    }

    public void BackMainMenu()
    {
        MainMenu.SetActive(true);
        HighscoreMenu.SetActive(false);
    }
}
