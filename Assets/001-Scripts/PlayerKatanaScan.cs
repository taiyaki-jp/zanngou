using UnityEngine;
public class PlayerKatanaScan : MonoBehaviour
{
    
    [SerializeField] private int difficultyEasy = 25;
    [SerializeField] private int difficultyNormal = 15;
    [SerializeField] private int difficultyHard =10;
    [SerializeField] private int difficultyNightmare = 5;
    [SerializeField] private AudioClip se;
    private readonly int _playerRotate = 90;
    private readonly int _enemyRotate = 0;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    /// <param name="collision"></param>
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _audioSource.PlayOneShot(se);                                  
        }
        if (90-difficultyNormal < _enemyRotate - _playerRotate 
            && _enemyRotate - _playerRotate < 90+difficultyNormal)
        {

        }else if (270-difficultyNormal < _enemyRotate - _playerRotate 
            && _enemyRotate - _playerRotate < 270-difficultyNormal)
        {

        }
    }
}