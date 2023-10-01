using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMarker : MonoBehaviour
{
    public EnemyType EnemyType;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
        Gizmos.color = Color.white;

    }
}
