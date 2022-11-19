using UnityEngine;

public abstract class Citizen : MonoBehaviour
{
    protected IMovable _movable;
    protected ISpeakable _speakable;
    protected IListenable _listenable;
    
    protected abstract void InitBehaviors();

    public void CitizenMove()
    {
        _movable.Move();
    }

    public void CitizenSpeak()
    {
        _speakable.Speak();
    }

    public void CitizenListen(string phrase)
    {
        _listenable.Listen(phrase);
    }
}
