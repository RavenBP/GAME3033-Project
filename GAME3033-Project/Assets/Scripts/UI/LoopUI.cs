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
        // TODO: Implement better concatenation for strings.
        loopText.text = "Loop: " + GameManager.Instance.loopCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Make more efficient
        loopText.text = "Loop: " + GameManager.Instance.loopCount.ToString();
    }
}
