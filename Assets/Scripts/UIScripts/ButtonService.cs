using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonService : MonoBehaviour
{
    public void Restart()
    {
        LoadManager.Instance.ReloadScene();
    }

    public void NextLevel()
    {
        LoadManager.Instance.LoadNextLevel();
    }

    public void LoadLevel(int _levelIndex)
    {
        LoadManager.Instance.LoadScene(_levelIndex + 1);
    }
}
