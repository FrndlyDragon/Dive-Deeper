using UnityEngine;
using UnityEngine.UI;

public class MenuSettingScripts : MonoBehaviour
{
    public GameObject warningPopUp;
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

    public void LastScene() {
        GameManager.Instance.LoadLastScene();
    }
}
