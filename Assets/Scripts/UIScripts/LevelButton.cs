using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    string currentLevel;
    int highestUnlocked;
    private void OnEnable()
    {
        currentLevel = gameObject.transform.Find("Index").GetComponent<TextMeshProUGUI>().text;
        highestUnlocked = PlayerPrefs.GetInt("HighestUnlocked");

        LoadHighScore();
        HideSelf();
    }


    private void HideSelf()
    {
        //feito meio com a bunda só pra corrigir o bug rápido, tenho que almoçar
        int current = int.Parse(currentLevel);
        if (highestUnlocked < current)
        {
            gameObject.SetActive(false);
        }
        if (currentLevel == "01")
        {

            gameObject.SetActive(true);
        }
    }

    private void LoadHighScore()
    {
        string hs = PlayerPrefs.GetInt("HighScore_" + currentLevel, 0).ToString();
        gameObject.transform.Find("HS").GetComponent<TextMeshProUGUI>().text = hs;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
