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

    public void RemoveSceneByType(Type type)
    {
        for(int i = 0; i < Scenes.Count; i++)
        {
            if(Scenes[i].GetType() == type)
            {
                RemovalQueue.Add(Scenes[i]);
                break;
            }
        }
    }
}