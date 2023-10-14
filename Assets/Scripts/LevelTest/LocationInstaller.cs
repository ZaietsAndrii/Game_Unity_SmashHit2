using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Common
{
    public class LocationInstaller : MonoInstaller, IInitializable
    {
        public Transform StartPoint;
        public GameObject playerPrefab;
        public EnemyMarker[] enemyMarkers;

        public override void InstallBindings()
        {
            BindInstallerInterfaces();
            BindPlayer();
            BindEnemyFactory();
            Initialize();
        }

        private void BindEnemyFactory()
        {
            Container
                .Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();
        }

        private void BindInstallerInterfaces()
        {
            Container
                .BindInterfacesTo<LocationInstaller>()
                .FromInstance(this)
                .AsSingle();
        }

        private void BindPlayer()
        {
            GameObject _playerPrefab = Container.
                InstantiatePrefab(playerPrefab, StartPoint.position, Quaternion.identity, null);
            //PlayerController playerController = Container
            //    .InstantiatePrefabForComponent<PlayerController>(playerPrefab, StartPoint.position, Quaternion.identity, null);

            Container.Bind<PlayerInputs>()
                .FromInstance(_playerPrefab.GetComponent<PlayerInputs>())
                .AsSingle();

            Container.Bind<PlayerInputs>().FromInstance(_playerPrefab.GetComponent<PlayerInputs>()).AsSingle();

        }

        public void Initialize()
        {
            var enemyFactory = Container.Resolve<IEnemyFactory>(); // Better don't do it

            foreach (EnemyMarker marker in enemyMarkers)
            {
                enemyFactory.Create(marker.EnemyType, marker.transform.position);
            }
        }
    }
}
