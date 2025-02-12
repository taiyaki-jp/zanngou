using System;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    private GameObject _player;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Hit(Quaternion enemyRotation)
    {
        Debug.Log(enemyRotation.eulerAngles);
    }
}
