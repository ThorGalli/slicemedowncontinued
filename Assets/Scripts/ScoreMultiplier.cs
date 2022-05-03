using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    [SerializeField] int multiplier;
    public int GetMultiplier() {
        return multiplier;
    }
}
