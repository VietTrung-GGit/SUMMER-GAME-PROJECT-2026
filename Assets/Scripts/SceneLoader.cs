using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneNameEnum sceneNameEnum;
    private Button sceneLoadButton;

    private void Awake()
    {
        sceneLoadButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        sceneLoadButton.onClick.AddListener(LoadScene);
    }

    private void OnDisable()
    {
        sceneLoadButton.onClick.RemoveListener(LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneNames.GetSceneName(sceneNameEnum));
    }
}