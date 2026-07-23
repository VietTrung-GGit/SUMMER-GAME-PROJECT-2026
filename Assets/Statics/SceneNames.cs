public static class SceneNames
{
    private const string GAME_SCENE_NAME = "GameScene";
    private const string START_SCENE_NAME = "StartScene";
    private const string DIGITOPOLIS_SCENE_NAME = "DigitopolisScene";

    public static string GetSceneName(SceneNameEnum sceneNameEnum)
    {
        return sceneNameEnum switch
        {
            SceneNameEnum.Game => GAME_SCENE_NAME,
            SceneNameEnum.Digitopolis => DIGITOPOLIS_SCENE_NAME,
            SceneNameEnum.Start => START_SCENE_NAME,
            _ => START_SCENE_NAME
        };
    }
}