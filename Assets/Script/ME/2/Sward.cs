using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sward : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider SwardCollider;
    
    public ParticleSystem particle;
    void Start()
    {
        particle.Stop();
        SwardCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Debug.Log("OnTriggerEnter");
            particle.Play();
            Vector3 closestPoint = other.ClosestPoint(transform.position);
            Debug.Log(closestPoint);   
            
            particle.transform.position = closestPoint;

            StartCoroutine(DisableColliderTemporarily());
        }
        
    }
    private IEnumerator DisableColliderTemporarily()
    {
        SwardCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        SwardCollider.enabled = true;
    }
}

