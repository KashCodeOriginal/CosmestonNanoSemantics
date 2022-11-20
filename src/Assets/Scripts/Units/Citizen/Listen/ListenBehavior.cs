using UnityEngine;

public class ListenBehavior : IListenable
{
    public void Listen(GameObject player, GameObject companion, string phrase)
    {
        /*if (player.TryGetComponent(out PlayerSpeakable speakable))
        {
            //speakable.DialogSystem.CanStartNewDialog(player, companion, companion.GetComponent<Dialog>(), phrase);
        }*/
    }
}