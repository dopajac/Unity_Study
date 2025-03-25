using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int hp = 3;
    private Renderer playerColor;

    private void Start()
    {
        playerColor = GetComponent<Renderer>();
    }

    private void Update()
    {
        ChangeColor();
    }

    public void ChangeHP(int damege)
    {
        hp -= damege;
    }

    public void ChangeColor()
    {
        switch (hp)
        {
            case 3:
                playerColor.material.color = Color.gray;
                break;
            case 2:
                playerColor.material.color = Color.yellow;
                break;
            case 1:
                playerColor.material.color = Color.red;
                break;
            case 0:
                Destroy(gameObject);
                break;
                 
        }
    }
}
