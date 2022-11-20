using UnityEngine;

public interface IListenable
{
    public void Listen(GameObject player, GameObject companion, string phrase);
}