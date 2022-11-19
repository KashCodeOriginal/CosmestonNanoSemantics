public class ImperialCap : Citizen
{
    protected override void InitBehaviors()
    {
        _movable = new PatrolMoveBehavior();
        _speakable = new NoSpeakBehavior();
        _listenable = new NoListenBehavior();
    }
}