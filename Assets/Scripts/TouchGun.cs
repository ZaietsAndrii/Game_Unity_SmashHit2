using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TouchGun : MonoBehaviour
{
    public PlayerInputs playerInputs;
    public Transform throwPoint;
    [SerializeField] private GameObject cannonBallPrefab;
    [SerializeField] private float cannonBallForceImpulse;

    //[Inject]
    //public void Construct(PlayerInputs _playerInputs)
    //{
    //    playerInputs = _playerInputs;
    //}

    private void OnEnable()
    {
        playerInputs.OnStartTouch += Shoot;
    }

    private void OnDisable()
    {
        playerInputs.OnStartTouch -= Shoot;
    }

    public void Shoot(Vector2 position, float time)
    {
        GameObject cannonBallInstance = Instantiate(cannonBallPrefab, throwPoint.position, transform.rotation, null);

        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, transform.position.z + 5000));

        cannonBallInstance.GetComponent<Rigidbody>().AddForce(touchPosition.normalized * cannonBallForceImpulse, ForceMode.Impulse);
    }

}
