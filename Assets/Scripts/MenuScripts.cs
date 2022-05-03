using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour{
    public void LoadGame() {
        SceneManager.LoadScene("MainScene");
    }
    public void LoadMenu() {
        SceneManager.LoadScene("MenuScene");
    }
}
