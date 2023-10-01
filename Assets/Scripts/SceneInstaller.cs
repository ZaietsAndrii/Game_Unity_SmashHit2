using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cinemachine;
using Unity.VisualScripting;

public class SceneInstaller : MonoInstaller
{
    public GameObject playerPrefab;
    private GameObject _player;
    public Transform startPoint;

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
}
