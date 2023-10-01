using ModestTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HierarchyInstaller : MonoBehaviour
{
    public List<Transform> listObjectsFromMaxToMin;
    [HideInInspector] public List<MeshCollider> objectPieces;

    // dont't use in another class
    [HideInInspector] public List<float> _interimListWithCoordinates;
    [HideInInspector] public List<int> _InterimListWithIdexes;
    private void Start()
    {
        objectPieces = transform.GetComponentsInChildren<MeshCollider>().ToList();

        FindOrder();
        SetOrder();
    }

    private void FindOrder() // put in order from highest to downest
    {
        foreach (MeshCollider collider in objectPieces)
        {
            _interimListWithCoordinates.Add(collider.transform.localPosition.y);
        }

        for (int i = 0; i < _interimListWithCoordinates.Count; i++)
        {
            int indx = _interimListWithCoordinates.IndexOf(_interimListWithCoordinates.Max()); // take highest item
            _InterimListWithIdexes.Add(indx);

            _interimListWithCoordinates[indx] = -100;
        }

        for (int i = 0; i < _InterimListWithIdexes.Count; i++)
        {
            Transform obj = objectPieces[_InterimListWithIdexes[i]].transform;
            listObjectsFromMaxToMin.Add(obj);
        }
    }

    private void SetOrder()
    {
        for (int i = 0; i < listObjectsFromMaxToMin.Count - 1; i++)
        {
            listObjectsFromMaxToMin[i].GetComponent<FixedJoint>().connectedBody     
                = listObjectsFromMaxToMin[i + 1].GetComponent<Rigidbody>();
        }
    }
}
