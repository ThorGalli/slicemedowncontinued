
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour {
    private string level;

    private void OnEnable() {
        level = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore_" + level, 0).ToString();
    }
}
