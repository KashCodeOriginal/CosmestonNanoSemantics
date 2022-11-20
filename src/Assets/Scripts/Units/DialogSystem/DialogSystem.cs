using System;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Dialog _currentDialog;

    private int _phraseDialogIndex;

    public bool CanStartNewDialog(Dialog dialog, string startPlayerPhrase)
    {
        if (dialog.Phrases[0].PhraseText != startPlayerPhrase)
        {
            return false;
        }

        _phraseDialogIndex++;
        _currentDialog = dialog;
        return true;
    }

    public void ProcessDialog(string phrase)
    {
        if (_phraseDialogIndex < _currentDialog.Phrases.Count)
        {
            if (_currentDialog.Phrases[_phraseDialogIndex].Type == SpeakerType.Player)
            {
                if (_currentDialog.Phrases[_phraseDialogIndex].PhraseText == phrase)
                {
                    _phraseDialogIndex++;
                    ProcessDialog(null);
                }
            }
            else if (_currentDialog.Phrases[_phraseDialogIndex].Type == SpeakerType.Citizen)
            {
                Debug.Log(_currentDialog.Phrases[_phraseDialogIndex].PhraseText);
                _phraseDialogIndex++;
                ProcessDialog(null);
            }
        }
    }
    
}
