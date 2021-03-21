using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagable : MonoBehaviour
{
    public bool isPlayer = false;
    
 
    SpriteRenderer spriteRenderer;

    float timer = -21f;
    public bool isDamaged = false;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    //need a variable to keep track of how many hit points we have
    public int hitpoints = 3;

    //I need a function which will let other things hurt me
    public void Damage(int amount)
    {
        hitpoints -= amount;
        timer = .8f;
        spriteRenderer.color = Color.red;
        isDamaged = true;
        Debug.Log("took " + amount + "damage, hp is " + hitpoints);
    }
    //I need to continuously check if I have any health points
    // if no healthpoints, die
    private void Update()
    {
        if (timer != -21f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                spriteRenderer.color = Color.white;
                isDamaged = false;
                timer = -21f;
            }
        }
        if (hitpoints <= 0)
        {
            if (isPlayer)
            {
                //Load game over scene
                GetComponent<LoadScene>().Load();
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}
