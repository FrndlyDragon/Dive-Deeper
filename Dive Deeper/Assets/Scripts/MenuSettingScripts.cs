using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class MenuSettingScripts : MonoBehaviour
{
    public GameObject warningPopUp;
    public GameObject redoMenu;
    public GameObject settingsMenu;
    public Slider volSlider;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            volSlider.value = GameManager.Instance.volume;
            settingsMenu.SetActive(!settingsMenu.activeSelf);
            warningPopUp.SetActive(false);
        }
    }

    public void ChangeVolume(float volume) {
        SoundManager.instance.AdjustVolume(volume);
    }

    public void OpenSettings() {
        Debug.Log("Openning settings");
        volSlider.value = GameManager.Instance.volume;
        settingsMenu.SetActive(true);
    }

    public void CloseSettings() {
        Debug.Log("Closing Settings");
        settingsMenu.SetActive(false);
    }

    public void WarningPopUp() {
        warningPopUp.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void ClosePopUp() {
        settingsMenu.SetActive(true);
        warningPopUp.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void StartGame() {
        settingsMenu.SetActive(false);
        GameManager.Instance.LoadScene(1);
    }

    public void Reset() {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            return;
        }

        settingsMenu.SetActive(false);
        GameManager.Instance.LoadScene(1);
    }

    public void LastScene() {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            return;
        }

        redoMenu.SetActive(false);
        settingsMenu.SetActive(false);
        GameManager.Instance.LoadLastScene();
    }

    public void MainMenu() {
        redoMenu.SetActive(false);
        SoundManager.instance.PlaySound("Space_Calm", true);
        GameManager.Instance.LoadScene(0);
    }

    [YarnCommand("redo")]
    public void OpenRedoMenu() {
        redoMenu.SetActive(true);
    }
}
