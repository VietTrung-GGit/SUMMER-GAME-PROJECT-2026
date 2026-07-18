public static class SceneNames
{
    private const string GameSceneName = "Game";

    public static string GetSceneName(SceneNameEnum sceneNameEnum)
    {
        return sceneNameEnum switch
        {
            SceneNameEnum.GameScene => GameSceneName,
            _ => ""
        };
    }
}