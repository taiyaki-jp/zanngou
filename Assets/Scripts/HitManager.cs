using UnityEngine;

public class HitManager : MonoBehaviour
{
    private GameObject _player;
    private MainGameManager _gameManager;
    private FusumaFadeManager _fadeManager;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _gameManager = GameObject.Find("SingletonCanvas").GetComponent<MainGameManager>();
        _fadeManager = GameObject.Find("SingletonCanvas").GetComponent<FusumaFadeManager>();
    }

    public void Hit(Quaternion enemyRotation)
    {
        //Debug.Log($"enemy{enemyRotation.eulerAngles}\n \t   player{_player.transform.rotation.eulerAngles}");
        var xAngle =0f;

        if (Mathf.Abs(_player.transform.rotation.eulerAngles.y - enemyRotation.eulerAngles.y) < 10)
            xAngle = enemyRotation.eulerAngles.x - _player.transform.rotation.eulerAngles.x;
        else
            xAngle = enemyRotation.eulerAngles.x + _player.transform.rotation.eulerAngles.x;

        if (xAngle > 180) xAngle -= 360;
        xAngle=Mathf.Abs(xAngle);
        Debug.Log(xAngle-90);
        if (Mathf.Abs(xAngle - 90) < _gameManager.DiffcultyAngle)
        {
            Debug.Log("甘い!");
            _gameManager.BlockCount++;
        }
        else
        {
            Debug.Log("ぐはっ");
            _gameManager.HP--;
            if (_gameManager.HP == 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        _ = _fadeManager.Fade("Result");
    }
}
