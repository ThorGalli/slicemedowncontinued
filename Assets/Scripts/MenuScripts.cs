using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour{
    public void ReloadGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMenu() {
        SceneManager.LoadScene(0);
    }
}
