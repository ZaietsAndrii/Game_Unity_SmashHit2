using UnityEngine;
using Zenject;

public class TestTouch : MonoBehaviour
{
    //[SerializeField] private Camera mainCamera;
    PlayerInputs playerInputs;

    [Inject]
    public void Construct(PlayerInputs _playerInputs)
    {
        playerInputs = _playerInputs;
    }

    private void OnEnable()
    {
        playerInputs.OnEndTouch += Move;
    }

    private void OnDisable()
    {
        playerInputs.OnEndTouch -= Move;
    }

    private void Move(Vector2 position, float time)
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10));
    }

}
