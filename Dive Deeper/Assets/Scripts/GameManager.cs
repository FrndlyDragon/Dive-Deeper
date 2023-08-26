using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance

    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                
            }
            return _instance;
        }
    }

    public int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += UpdateScene;
    }

    public void UpdateScene(Scene s, LoadSceneMode mode) {
        sceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }

    [YarnCommand("load_last_scene")]
    public void LoadLastScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
