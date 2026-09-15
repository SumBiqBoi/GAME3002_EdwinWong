public abstract class AbstractGameState
{
    public AbstractGameState()
    {

    }

    public abstract void LoadGameState();

    public abstract void UnloadGameState();

    public abstract void Pause();

    public abstract void Resume();

    public abstract void Update();
}
