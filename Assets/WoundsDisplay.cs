using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoundsDisplay : MonoBehaviour
{
    Text display;
    public damagable hitPointsLeft;
    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = hitPointsLeft.hitpoints.ToString();
    }
}
