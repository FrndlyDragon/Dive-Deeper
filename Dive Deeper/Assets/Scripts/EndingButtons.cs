using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingButtons : MonoBehaviour
{
    public void ExitGame() {
        Application.Quit();
    }

    public void MainMenu() {
        GameManager.Instance.LoadScene(0);
        SoundManager.instance.StopSound("True_Ending");
    }
}
