using System;
using UnityEngine;




public class BreakGlass : MonoBehaviour
{
    [SerializeField] private Transform brokenGlass;
    [SerializeField] private float breakMagnitude = 10f;
    [SerializeField] private float radius = 4f;
    [SerializeField] private float explosionPower = 10f;
    [SerializeField] private float upwardForce = 3f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.magnitude > breakMagnitude)
        {
            other.gameObject.GetComponent<PlayerManager>().isInteracting = false;
            Destroy(gameObject);
            Instantiate(brokenGlass, transform.position, transform.localRotation);
            brokenGlass.transform.localScale = transform.localScale;
            var explosionPos = transform.position;
            var colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (var hit in colliders)
            {
                if (hit.GetComponent<Rigidbody>())
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(
                        explosionPower*other.relativeVelocity.magnitude,
                        explosionPos,radius,upwardForce);
                        
                }
            }
            
        }
    }
}

