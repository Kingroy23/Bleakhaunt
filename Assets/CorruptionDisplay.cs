using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorruptionDisplay : MonoBehaviour
{
    Text display;
    public Invisibility corruptionUpdate;
    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = corruptionUpdate.corruption.ToString();
    }
}
