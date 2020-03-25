using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartControl : MonoBehaviour
{
    
    public void StartControlFun()
    {
        SceneManager.LoadScene("Control Run");
    }
}
