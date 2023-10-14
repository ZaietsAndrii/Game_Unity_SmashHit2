using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject replacementPrefab;
    [SerializeField] private float collisionMultiplier = 10f;
    public float breakThreshold;
    public float explosionRudius;
    public bool broken;
    private void OnCollisionEnter(Collision collision)
    {
        if (broken) return;
        //print(collision.relativeVelocity.magnitude * collision.rigidbody?.mass);
        if (collision.relativeVelocity.magnitude * collision.rigidbody?.mass >= breakThreshold)
        {
            broken = true;
            GameObject replacement = Instantiate(replacementPrefab, transform.position, transform.rotation, null);

            InheritProperties(gameObject, replacement, gameObject.GetComponent<MeshRenderer>().material);

            Destroy(gameObject);

            Shoot(replacement, collision);
        }

    }

    private void InheritProperties(GameObject currentGameObject, GameObject replacement, Material material)
    {
        replacement.GetComponent<Transform>().localScale = currentGameObject.transform.GetComponent<Transform>().localScale;

        foreach (var item in replacement.GetComponentsInChildren<MeshRenderer>())
        {
            item.material = material;
        }
    }

    private void Shoot(GameObject replacement, Collision collision)
    {
        foreach (var rb in replacement.GetComponentsInChildren<Rigidbody>())
        {
            rb.AddExplosionForce
                (collision.relativeVelocity.magnitude * collisionMultiplier, collision.GetContact(0).point, explosionRudius); //collision.GetContact(0).point

            //rb.AddForce(-collision.transform.position.normalized * collisionMultiplier * collision.relativeVelocity.magnitude, ForceMode.Impulse);
        }
    }
}
