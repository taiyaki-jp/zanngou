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
        Debug.Log($"enemy{enemyRotation.eulerAngles}\n \t   player{_player.transform.rotation.eulerAngles}");
        var xAngle =0f;

        if (Mathf.Abs(_player.transform.rotation.eulerAngles.y - enemyRotation.eulerAngles.y) < 10)
            xAngle = enemyRotation.eulerAngles.x - _player.transform.rotation.eulerAngles.x;
        else
            xAngle = enemyRotation.eulerAngles.x + _player.transform.rotation.eulerAngles.x;

        if (xAngle > 180) xAngle -= 360;
        xAngle=Mathf.Abs(xAngle);
        Debug.Log(xAngle);

    }
}
