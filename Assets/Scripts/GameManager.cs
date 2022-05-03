using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] GameObject canvas;

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
        points *= m;
        canvas.transform.Find("WinPannel").gameObject.SetActive(true);
        canvas.transform.Find("PointIndicator").gameObject.SetActive(false);

    }
    public void PlayerLost() {
        canvas.transform.Find("DeathPannel").gameObject.SetActive(true);
        canvas.transform.Find("PointIndicator").gameObject.SetActive(false);
    }

}