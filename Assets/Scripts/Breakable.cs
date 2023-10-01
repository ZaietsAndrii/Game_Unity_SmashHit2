using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject replacementPrefab;
    [SerializeField] private float breakThreshold = 20f;
    [SerializeField] private float collisionMultiplier = 10f;
    [SerializeField] private float explosionRudius = 10f;
    public bool broken;
    private void OnCollisionEnter(Collision collision)
    {
        if (broken) return;
        print(collision.relativeVelocity.magnitude * collision.rigidbody?.mass);
        if (collision.relativeVelocity.magnitude * collision.rigidbody?.mass >= breakThreshold)
        {
            broken = true;
            Destroy(gameObject);
            var replacement = Instantiate(replacementPrefab, transform.position, transform.rotation, null);

            //print(transform.parent.GetComponent<Transform>().localScale);
            replacementPrefab.GetComponent<Transform>().localScale = transform.parent.GetComponent<Transform>().localScale;

            var rbs = replacement.GetComponentsInChildren<Rigidbody>();

            foreach (var rb in rbs)
            {
                rb.AddExplosionForce
                    (collision.relativeVelocity.magnitude * collisionMultiplier, collision.GetContact(0).point, explosionRudius); //collision.GetContact(0).point

                //rb.AddForce(-collision.transform.position.normalized * collisionMultiplier * collision.relativeVelocity.magnitude, ForceMode.Impulse);
            }
        }


    }
}
