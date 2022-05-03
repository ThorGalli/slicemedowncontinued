using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] Transform gameDetails;
    [SerializeField] GameObject scoreIndicator;
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
        points = 0;
        _instance = this;
        level = SceneManager.GetActiveScene().name;
        highScore = PlayerPrefs.GetInt("HighScore_" + level, 0);
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
        TextMeshProUGUI endGameMessage = gameDetails.Find("EndGameMessage").transform.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI multiplierMessage = gameDetails.Find("MultiplierMessage").transform.GetComponent<TextMeshProUGUI>();
        Image bgImage = gameDetails.Find("BackGroundImage").GetComponent<Image>();

        multiplierMessage.text = "("+m.ToString() + " x " + points.ToString()+")";
        endGameMessage.text = "YOU WIN!";

        points *= m;
        bgImage.color = new Color(.5f, 1, 0.4f, 0.5f);
        EndGame();
    }
    public void PlayerLost() {
        TextMeshProUGUI endGameMessage = gameDetails.Find("EndGameMessage").transform.GetComponent<TextMeshProUGUI>();
        Image bgImage = gameDetails.Find("BackGroundImage").GetComponent<Image>();

        endGameMessage.text = "YOU LOSE!";
        endGameMessage.color = Color.red;

        bgImage.color = new Color(1, 0.5f, 0.4f, 0.5f);
        EndGame();
    }

    public void EndGame() {
        ManageHighScore();
        gameDetails.gameObject.SetActive(true);
        scoreIndicator.gameObject.SetActive(false);
    }

    private void ManageHighScore() {
        if (points > highScore) {
            highScore = points;
            PlayerPrefs.SetInt("HighScore_" + level, highScore);
        }
    }
}