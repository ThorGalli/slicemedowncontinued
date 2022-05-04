using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayClipOnClick : MonoBehaviour {
    [SerializeField] AudioClip clip;

    void Start() {
        GetComponent<Button>().onClick.AddListener(CallPop);
    }

    private void CallPop() {
        UISoundManager.Instance.PlayPop(clip);
    }
}
