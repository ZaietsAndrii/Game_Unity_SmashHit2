using UnityEngine;
using Zenject;


public class SceneInstaller : MonoInstaller
{
    public GameObject playerPrefab;
    private GameObject _player;
    public Transform startPoint;
    public EventManager gameManager;

    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        _player =
            Container.InstantiatePrefab(playerPrefab, startPoint.position, startPoint.rotation, null);

        Container
            .Bind<PlayerInputs>()
            .FromInstance(_player.GetComponent<PlayerInputs>())
            .AsSingle();
    }

    //private void BindEventManager()
    //{
    //    Container
    //.Bind<EventManager>()
    //.FromComponentsOn(gameManager.gameObject)
    //.AsSingle();
    //}


}
