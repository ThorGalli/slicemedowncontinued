using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    string level;
    private void OnEnable() {
        level = gameObject.transform.Find("Index").GetComponent<TextMeshProUGUI>().text;
        string hs = PlayerPrefs.GetInt("HighScore_" + level, 0).ToString();
        gameObject.transform.Find("HS").GetComponent<TextMeshProUGUI>().text = hs;
    }

    public void LoadLevel() {
        SceneManager.LoadScene(level);
    }
}
