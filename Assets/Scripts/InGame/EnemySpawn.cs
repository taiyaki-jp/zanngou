using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField,Label("敵の刀")] private GameObject _enemyPrefab;
    [SerializeField,Label("スポーン位置")] private Transform _spawnPoint;

    [SerializeField,BoxGroup("スポーン間隔"),Label("最大値(秒)")] private float _spawnIntervalMax=1.5f;
    [SerializeField,BoxGroup("スポーン間隔"),Label("最小値(秒)")] private float _spawnIntervalMin=0.5f;

    private MainGameVariables _variables;

    private void Start()
    {
        _variables = GameObject.Find("SingletonCanvas").GetComponent<MainGameVariables>();
    }

    public async UniTask Spawn(CancellationToken token)
    {
        for (int i = 0; i < 100; i++)
        {
            Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.Euler(Random.Range(0f, 360f), 90f, 0f));
            await UniTask.Delay(TimeSpan.FromSeconds(Random.Range(_spawnIntervalMin, _spawnIntervalMax)),
                cancellationToken:token);
        }
    }
}
