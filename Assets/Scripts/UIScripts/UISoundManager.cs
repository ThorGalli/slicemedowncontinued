using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour {

    private static UISoundManager _instance;

    private AudioSource auds;
    private AudioClip pop;

    public static UISoundManager Instance {
        get {
            if (_instance == null) {
                Debug.Log("UISoundsManager is null");
            }
            return _instance;
        }
    }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else { 

        _instance = this;
        DontDestroyOnLoad(_instance);
        auds = GetComponent<AudioSource>();
        pop = auds.clip;

        }
    }

    public void PlayPop(AudioClip clip) {
        if (clip == null) {
            auds.PlayOneShot(pop);
        } else {
            auds.PlayOneShot(clip);
        }
    }

}
