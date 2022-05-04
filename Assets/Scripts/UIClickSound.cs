using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickSound : MonoBehaviour {
    private AudioSource auds;
    private AudioClip pop;
    [SerializeField] AudioClip backPop;

    private void Awake() {
        auds = GetComponent<AudioSource>();
        pop = auds.clip;
    }
    public void PlayPop() => auds.PlayOneShot(pop);

    public void PlayBackPop() => auds.PlayOneShot(backPop);
}
