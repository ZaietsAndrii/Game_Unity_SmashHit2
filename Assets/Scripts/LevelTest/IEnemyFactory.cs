using UnityEngine;

public interface IEnemyFactory
{
    void Load();
    void Create(EnemyType enemyType, Vector3 at);
}
