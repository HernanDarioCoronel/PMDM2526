using System;
using UnityEngine;

[RequireComponent(typeof(SceneController))]
public class Win : MonoBehaviour
{
    public string nextSceneName;
    public SceneController sceneController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sceneController.ChangeScene(nextSceneName);
        }
    }
}
