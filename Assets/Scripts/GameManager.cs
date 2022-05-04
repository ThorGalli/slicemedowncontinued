using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameUI;
    private Transform gameDetails;
    private Transform canvas;

    private int highScore;
    string level;
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
        _instance = this;
        points = 0;
        level = SceneManager.GetActiveScene().name;
        highScore = PlayerPrefs.GetInt("HighScore_" + level, 0);
        canvas = gameUI.transform.Find("Canvas");
        gameDetails = canvas.transform.Find("GameDetails");
    }

    public void AddPoint() {
        points++;
        player.GetComponent<PlayerBehaviour>().justCut();
    }

    public int GetPoints() {
        return points;
    }

    public string GetLevel() {
        return level;
    }

    public void PlayerWon(int m) {
        TextMeshProUGUI endGameMessage = gameDetails.Find("EndGameMessage").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI multiplierMessage = gameDetails.Find("MultiplierMessage").GetComponent<TextMeshProUGUI>();
        Image bgImage = gameDetails.Find("BackGroundImage").GetComponent<Image>();

        multiplierMessage.text = "("+m.ToString() + " x " + points.ToString()+")";
        endGameMessage.text = "YOU WIN!";

        points *= m;
        bgImage.color = new Color(.5f, 1, 0.4f, 0.5f);
        canvas.Find("GameDetails").Find("Next").gameObject.SetActive(true);
        EndGame();
    }
    public void PlayerLost() {
        TextMeshProUGUI endGameMessage = gameDetails.Find("EndGameMessage").GetComponent<TextMeshProUGUI>();
        Image bgImage = gameDetails.Find("BackGroundImage").GetComponent<Image>();

        endGameMessage.text = "YOU LOSE!";
        endGameMessage.color = Color.red;

        bgImage.color = new Color(1, 0.5f, 0.4f, 0.5f);
        EndGame();
    }

    public void EndGame() {
        ManageHighScore();
        gameDetails.gameObject.SetActive(true);
        canvas.Find("ScoreIndicator").gameObject.SetActive(false);
        canvas.Find("JumpButton").gameObject.SetActive(false);
        canvas.Find("PauseButton").gameObject.SetActive(false);
    }

    private void ManageHighScore() {
        if (points > highScore) {
            highScore = points;
            PlayerPrefs.SetInt("HighScore_" + level, highScore);
        }
    }
}