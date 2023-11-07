using UnityEngine;

public class EnemyDel : MonoBehaviour
{
    /// <summary>
    /// �Փ˂�����
    /// </summary>
    /// <param name="collision"></param>
    //se�̎󂯎��
    
    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�
        if (collision.gameObject.tag == "Player")
        {
            // 0.1�b��ɏ�����
            Destroy(gameObject, 0.1f);
            //����炷
            
        }
    }
}