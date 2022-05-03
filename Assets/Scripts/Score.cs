using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {

    private void Update() {
        string score = GameManager.Instance.GetPoints().ToString();
        gameObject.GetComponent<TextMeshProUGUI>().text = score;
    }

}
