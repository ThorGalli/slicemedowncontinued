using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    [SerializeField] GameObject player;

    public void Jump() {
        player.GetComponent<PlayerBehaviour>().Jump();
    }
}
