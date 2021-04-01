using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text resultsText;
    [SerializeField]
    private GameObject backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (GameManager.Instance.reachedEnd == true)
        {
            resultsText.text = "GAME COMPLETED";
            // TODO: Change background image.
        }
        else if (GameManager.Instance.reachedEnd == false)
        {
            resultsText.text = "GAME OVER";
            // TODO: Change background image.
        }
    }
}
