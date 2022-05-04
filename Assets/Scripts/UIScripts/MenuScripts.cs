using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour{
    public void ReloadGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void PauseGame() {
        Time.timeScale=0;
    }
    public void NextLevel() {
        int nextLevel = int.Parse(SceneManager.GetActiveScene().name)+1;
        string nextLevelName;

        if (nextLevel < 10) 
            nextLevelName = "0" + nextLevel.ToString();
        else 
            nextLevelName = nextLevel.ToString();
        
        SceneManager.LoadScene(nextLevelName);
    }

    public void ResumeGame() {
        Time.timeScale = 1;
    }

    public void ResetSave() {
        PlayerPrefs.DeleteAll();
    }
}
