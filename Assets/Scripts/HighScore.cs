
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour {
    private string level;

    private void OnEnable() {
        level = GameManager.Instance.GetLevel();
    }

    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore_" + level, 0).ToString();
    }
}
