using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyFactory : IEnemyFactory
{
    private const string EnemyCube = "Enemy_Cube";
    private const string EnemySphere = "Enemy_Sphere";
    private readonly DiContainer _diContainer;

    private Object _sphereEnemyPrefab;
    private Object _cubeEnemyPrefab;

    public EnemyFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public void Load()
    {
        _sphereEnemyPrefab = Resources.Load(EnemySphere);
        _cubeEnemyPrefab = Resources.Load(EnemyCube);
    }

    public void Create(EnemyType enemyType, Vector3 at)
    {
        switch (enemyType)
        {
            case EnemyType.Melee:
                _diContainer.InstantiatePrefab(_cubeEnemyPrefab, at, Quaternion.identity, null);
                break;
            case EnemyType.Ranged:
                _diContainer.InstantiatePrefab(_sphereEnemyPrefab, at, Quaternion.identity, null);
                break;
        }
    }
}
