using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int hp = 3;
    private Renderer playerColor;
    public Boss boss;
    private Collider playerCollider;  
    
    
    private void Start()
    {
        playerColor = GetComponent<Renderer>();
        playerCollider = GetComponent<Collider>(); 
    }

    private void Update()
    {
        ChangeColor();
    }

    public void ChangeHP(int damege)
    {
        hp -= damege;
        ChangeColor();
        StartCoroutine(DisableCollider());
    }
    IEnumerator DisableCollider()
    {
        playerCollider.enabled = false;  
        yield return new WaitForSeconds(3f);  
        playerCollider.enabled = true;   
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
    private void OnTriggerEnter(Collider other)
    {
        GameObject rootObject = other.transform.root.gameObject;
        int bossLayer = LayerMask.NameToLayer("Boss");

        if (rootObject.layer == bossLayer)
        {
            ChangeHP(1);
            
        }
    }

    
}
