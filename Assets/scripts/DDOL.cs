using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(this);
    }
}
