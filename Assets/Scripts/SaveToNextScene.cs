using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveToNextScebe : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
