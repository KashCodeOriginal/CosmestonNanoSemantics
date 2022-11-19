using UnityEngine;

public class ListenBehavior : IListenable
{
    public void Listen(string phrase)
    {
        Debug.Log(phrase);
    }
}