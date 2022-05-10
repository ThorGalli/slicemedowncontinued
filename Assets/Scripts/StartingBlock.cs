using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartingBlock : MonoBehaviour
{

    private void Start()
    {
        string text = "Level\n" + SceneManager.GetActiveScene().name;
        gameObject.transform.Find("LEVEL").GetComponent<TextMeshPro>().text = text;
    }


}
