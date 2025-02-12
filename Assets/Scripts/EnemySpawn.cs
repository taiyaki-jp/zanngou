using NaughtyAttributes;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField,Label("敵の刀")] private GameObject _enemyPrefab;
    [SerializeField,Label("スポーン位置")] private Transform _spawnPoint;

    [SerializeField,BoxGroup("スポーン間隔"),Label("最大値")] private float _spawnIntervalMax;
    [SerializeField,BoxGroup("スポーン間隔"),Label("最小値")] private float _spawnIntervalMin;
}
