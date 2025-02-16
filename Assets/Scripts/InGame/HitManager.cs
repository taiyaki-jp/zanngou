using UnityEngine;

public class HitManager : MonoBehaviour
{
    private GameObject _player;
    private MainGameVariables _gameVariables;
    private SoundPlayer _soundPlayer;
    private MainGameManager _gameManager;
    private InGameUIManager _inGameUIManager;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _gameVariables = GameObject.Find("SingletonCanvas").GetComponent<MainGameVariables>();
        _soundPlayer = GameObject.Find("SoundSingleton").GetComponent<SoundPlayer>();
        _gameManager = this.GetComponent<MainGameManager>();
        _inGameUIManager = this.GetComponent<InGameUIManager>();
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
        if (Mathf.Abs(xAngle - 90) < _gameVariables.DiffcultyAngle)
        {
            Debug.Log("甘い!");
            _soundPlayer.PlaySound(SoundEnum.KatanaHit);
            _gameVariables.BlockCount++;
        }
        else
        {
            Debug.Log("ぐはっ");
            if(_gameVariables.NowDiffculty==4) _soundPlayer.PlaySound(SoundEnum.KatanaCut);
            else _soundPlayer.PlaySound(SoundEnum.Damage);
            _gameVariables.HP--;
            _inGameUIManager.ChangeLife();
            if (_gameVariables.HP == 0)
            {
                _gameManager.GameOver();
            }
        }
    }
}
