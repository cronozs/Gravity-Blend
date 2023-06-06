using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    public int scenee;
    private string  _currenteScene;
    private void Start()
    {
        _currenteScene = SceneManager.GetActiveScene().name;
    }
    public void Recargar()
    {
        SceneManager.LoadScene(_currenteScene);
    }

    public void Change()
    {
        SceneManager.LoadScene(scenee);
    }
}
