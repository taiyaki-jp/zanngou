using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [SerializeField] float _mousePosZ = 10.0f;
    void Update()
    {
        var mousePos = Input.mousePosition;
        this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, _mousePosZ));
    }
}
