namespace Rhythia.Engine.Scene;

public class SceneHandler
{
    List<IScene> Scenes = [];

    List<IScene> RemovalQueue = [];


    public void UpdateAllScenes(Window window, double dt)
    {
        foreach(var scene in Scenes)
            scene.Update(window, dt);

        foreach(var scene in RemovalQueue)
            Scenes.Remove(scene);
    }

    public void RenderAllScenes(Window window)
    {
        foreach(var scene in Scenes)
            scene.Render(window);
    }

    public void ClearScenes() {
        Scenes = new List<IScene>();
    }

    public void AddScene(IScene scene) {
        Scenes.Add(scene);
    }

    public void RemoveSceneByType<T>() where T : IScene
    {
        for(int i = 0; i < Scenes.Count; i++)
        {
            if(Scenes[i] is T)
            {
                RemovalQueue.Add(Scenes[i]);
                break;
            }
        }
    }

    public IScene? GetSceneByType<T>() where T : IScene
    {
        for(int i = 0; i < Scenes.Count; i++)
        {
            if(Scenes[i] is T)
                return (T)Scenes[i];
        }
        return null;
    }

    public IScene? GetSceneByTypeIndexed<T>(int which) where T : IScene
    {
        int j = 0;
        for(int i = 0; i < Scenes.Count; i++)
        {
            if(Scenes[i] is T)
            {
                if(j >= which) return Scenes[i];
                else j++;
            }
        }
        return null;
    }
}