using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] GameObject canvas;
    [SerializeField] TextMeshProUGUI endGameMessage;
    [SerializeField] Image bgImage; 

    private static GameManager _instance;

    private int points;

    public static GameManager Instance {
        get {
            if (_instance == null) {
                Debug.Log("Game manager is null");
            }
            return _instance;
        }
    }

    private void Awake() {
        points = 0;
        _instance = this;
    }

    public void addPoint() {
        points++;
        player.GetComponent<PlayerBehaviour>().justCut();
    }

    public int getPoints() {
        return points;
    }

    public void PlayerWon(int m) {
        string multiplierMessage = m.ToString() + "x" + points.ToString();
        endGameMessage.text = "YOU WIN!";
        points *= m;
        bgImage.color = new Color(.5f, 1, 0.4f, 0.35f);
        EndGame();
    }
    public void PlayerLost() {
        endGameMessage.text = "YOU LOSE!";
        bgImage.color = new Color(1, 0.5f, 0.4f, 0.35f);
        EndGame();
    }

    public void EndGame() {
        ManageHighScore();
        canvas.transform.Find("EndGamePannel").gameObject.SetActive(true);
        canvas.transform.Find("PointIndicator").gameObject.SetActive(false);
    }

    private void ManageHighScore() {

    }
}