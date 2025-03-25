using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayControllerMy : MonoBehaviour
{
    public LayerMask worldLayer;
    public Boss boss;
    public Player2[] players2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SearchLayer();
    }

    void SearchLayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo,10, worldLayer ))
            {
                var gameObject = hitInfo.collider.gameObject;
                if (gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    foreach (var player2 in players2)
                    {
                        if (player2.gameObject == gameObject)
                        {
                            player2.ChangeHP(-1);
                        }

                    
                    }    
                }

                if (gameObject.layer == LayerMask.NameToLayer("Boss"))
                {
                    boss.Bosshit(1.0f);
                }
            }
        }

        
    } 
}

