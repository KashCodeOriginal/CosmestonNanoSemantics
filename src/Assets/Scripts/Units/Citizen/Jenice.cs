public class Jenice : Citizen
{
    protected override void InitBehaviors()
    {
        _movable = new NoMoveBehavior();
        _speakable = new DialogBehavior();
        _listenable = new ListenBehavior();
    }

    private void Start()
    {
        InitBehaviors();
    }
}