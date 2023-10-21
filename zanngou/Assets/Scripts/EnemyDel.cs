using UnityEngine;

public class EnemyDel : MonoBehaviour
{
    /// <summary>
    /// Õ“Ë‚µ‚½
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        // Õ“Ë‚µ‚½‘Šè‚ÉPlayerƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
        if (collision.gameObject.tag == "Player")
        {
            // 0.1•bŒã‚ÉÁ‚¦‚é
            Destroy(gameObject, 0.1f);
        }
    }
}