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
            RaycastHit[] hits = Physics.RaycastAll(ray, 10, worldLayer);

            if (hits.Length > 0)
            {
                // 가장 가까운 오브젝트 찾기
                RaycastHit closestHit = hits[0];
                float minDistance = hits[0].distance;

                foreach (var hit in hits)
                {
                    if (hit.distance < minDistance)
                    {
                        minDistance = hit.distance;
                        closestHit = hit;
                    }
                }

                GameObject gameObject = closestHit.collider.gameObject;

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

