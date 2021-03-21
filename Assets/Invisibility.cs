using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{

    public bool isInvisible = false;
    SpriteRenderer spriteRenderer;
    public damagable D;

    public int corruption = 0;

    int frameCounter = 0;

    public int corruptionThreshold = 119;

    float timer = -21f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Invisible"))
        {
            spriteRenderer.color = Color.gray;
            isInvisible = true;

            frameCounter++;

            if (frameCounter > corruptionThreshold)
            {
                corruption++;
                frameCounter = 0;
            }
            
        }
        else
        {
            if (D.isDamaged != true)
            {
                spriteRenderer.color = Color.white;
                isInvisible = false;
            }
            
        }
    }

    public bool returnInvisibility()
    {
        return isInvisible;
    }

    
}
