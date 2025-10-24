using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    VisualElement root;

    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }
}
