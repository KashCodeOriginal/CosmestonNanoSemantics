public class Deetsan : Citizen
{
    protected override void InitBehaviors()
    {
        _movable = new NoMoveBehavior();
        _speakable = new QuestBehavior();
        _listenable = new ListenBehavior();
    }
}