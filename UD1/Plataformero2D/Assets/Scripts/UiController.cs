using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    public string nextSceneName;
    VisualElement root;
    SceneController sceneController;

    void OnEnable()
    {
        sceneController = GetComponent<SceneController>();
        root = GetComponent<UIDocument>().rootVisualElement;

        Button start = root.Q<Button>("start-button");
        Button exit = root.Q<Button>("exit-button");

        start.clicked += OnStartClicked;
        exit.clicked += OnExitClicked;
    }

    void OnStartClicked()
    {
        sceneController.ChangeScene(nextSceneName);
    }
    void OnExitClicked()
    {
        sceneController.QuitGame();
    }
}
