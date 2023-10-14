using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class BreakableButton : MonoBehaviour
{
    //public delegate void TrigerActivatedDelegate();
    //public event TrigerActivatedDelegate OnTrigerActivatedEvent;
    public event Action OnTrigerActivatedEvent;

    private void Start()
    {
        //if (gameObject.GetComponent<EmptyMarker>().isActiveAndEnabled)
        //{
        //    print("lol");
        //}

        //Destroy(gameObject.GetComponent<EmptyMarker>());

        //if (!gameObject.GetComponent<EmptyMarker>().isActiveAndEnabled)
        //{
        //    print("kek");
        //}
    }
    private void OnDestroy()
    {
        Destroy(gameObject.GetComponent<EmptyMarker>());
        OnTrigerActivatedEvent?.Invoke();
    }
}
