using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void GetName()
    {
        DataPersistenceHandler.Instance.playerName = nameInputField.text;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
