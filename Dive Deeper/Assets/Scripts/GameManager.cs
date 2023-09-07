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

    public int sceneIndex = 1;
    public float volume = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateScene() {
        if (SceneManager.GetActiveScene().buildIndex > 1) {
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }

    [YarnCommand("load_last_scene")]
    public void LoadLastScene() {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }

    [YarnCommand("load_scene")]
    public void LoadScene(int sceneIndex) {
        UpdateScene();
        SceneManager.LoadScene(sceneIndex);
    }
}
