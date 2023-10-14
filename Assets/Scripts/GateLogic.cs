using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class GateLogic : MonoBehaviour
{
    public BreakableButton[] trigersToOpen;
    [SerializeField] private Material breakableMaterial;

    private float breakTreashold;

    //public delegate void TrigerActivateHandler(GameObject sender);
    //public event TrigerActivateHandler OnTrigerActivateEvent;

    private void Start()
    {
        breakTreashold = 150f;
    }

    private void OnEnable()
    {
        foreach (var triger in trigersToOpen)
        {
            triger.OnTrigerActivatedEvent += CheckTrigeersStatus;
        }
    }

    private void OnDisable()
    {
        foreach (var triger in trigersToOpen)
        {
            triger.OnTrigerActivatedEvent -= CheckTrigeersStatus;
        }
    }

    private void CheckTrigeersStatus()
    {
        foreach (BreakableButton triger in trigersToOpen)
        {
            if (triger != null && triger.GetComponent<EmptyMarker>().isActiveAndEnabled) { return; }
        }

        ChangeGateStateToBreakable();
    }

    private void ChangeGateStateToBreakable()
    {
        gameObject.GetComponent<MeshRenderer>().material = breakableMaterial;
        gameObject.GetComponent<Breakable>().breakThreshold = breakTreashold;
    }
}
