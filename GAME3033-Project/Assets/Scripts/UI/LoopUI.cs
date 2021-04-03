using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text loopText;

    // Start is called before the first frame update
    void Start()
    {
        loopText.text = $"Loop: {GameManager.Instance.loopCount}";
    }

    // Update is called once per frame
    void Update()
    {
        loopText.text = $"Loop: {GameManager.Instance.loopCount}";
    }
}
