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

    public InventoryItem selectedItem;

    public int sceneIndex;
    public float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += UpdateScene;
    }

    public void UpdateScene(Scene s, LoadSceneMode mode) {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    [YarnCommand("load_last_scene")]
    public void LoadLastScene() {
        SceneManager.LoadScene(sceneIndex);
    }

    [YarnCommand("load_scene")]
    public void LoadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
}
