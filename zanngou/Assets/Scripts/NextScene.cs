using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // UnityEngine.SceneManagemntの機能を使用
 
public class NextScene : MonoBehaviour
{
    public void change_button()
    {
        SceneManager.LoadScene("SampleScene");
    }
}