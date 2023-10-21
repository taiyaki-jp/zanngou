using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    //�v���n�u
    public GameObject Sword;
    //�r�g�g������С��
    public float minTime = 0.3f;
    //�r�g�g�������
    public float maxTime = 2.5f;
    //�����ɕr�g�g��
    private float interval;
    //�U�^�r�g
    private float time = 0f;

    public float RotateMin = 0f;
    public float RotateMax = 360f;
    private void Start()
    {
        interval = GetRandomTime();
    }

    // Update is called once per frame

    private void Update()
    {
        //�r�gӋ�y
        time += Time.deltaTime;
        float z = Random.Range(RotateMin, RotateMax);

        //�U�^�r�g�����ɕr�g�ˤʤä��Ȥ�(���ɕr�g���󤭤��ʤä��Ȥ�)
        if (time > interval)
        {
            //���󥹥��󥹻�����(���ɤ���)
            GameObject NewSword = Instantiate(Sword);
            //���ɤ����������ˤ�Q������
            NewSword.transform.position = new Vector3(0, 2, 5);
            NewSword.transform.Rotate(0, 0, z);
            time = -999999999999999999;
        }
    }

    //������ʕr�g�����ɤ����v��
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }
    
}
