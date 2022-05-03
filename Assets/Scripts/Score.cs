using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Score : MonoBehaviour {
    string score;

    private void Update() {
        score = GameManager.Instance.getPoints().ToString();
        gameObject.GetComponent<TextMeshProUGUI>().text = score;
    }

}
