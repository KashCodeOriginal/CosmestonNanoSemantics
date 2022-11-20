using UnityEngine;
using ai.nanosemantics;
using UnityEngine.Events;

public class DialogSystem : MonoBehaviour
{
    public event UnityAction IsDialogEnded;
    
    [SerializeField] private Dialog _currentDialog;

    private int _phraseDialogIndex;
    private TTS _tts;

    public void SetUp(TTS tts)
    {
        _tts = tts;
    }

    public bool CanStartNewDialog(Dialog dialog, string startPlayerPhrase)
    {
        foreach (var phrase in dialog.Phrases[0].PhraseText)
        {
            if (phrase == startPlayerPhrase)
            {
                _phraseDialogIndex++;
                _currentDialog = dialog;
                return true;
            }
        }

        return false;
    }

    public void ProcessDialog(string currentPhrase)
    {
        if (_phraseDialogIndex < _currentDialog.Phrases.Count)
        {
            if (_currentDialog.Phrases[_phraseDialogIndex].Type == SpeakerType.Player)
            {
                foreach (var phrase in _currentDialog.Phrases[_phraseDialogIndex].PhraseText)
                {
                    if (phrase == currentPhrase)
                    {
                        _phraseDialogIndex++;
                        ProcessDialog(null);
                    }
                }
            }
            else
            {
                _tts.SendText(_currentDialog.Phrases[_phraseDialogIndex].PhraseText[0]);
                _phraseDialogIndex++;
                ProcessDialog(null);
            }
        }
        else
        {
            _currentDialog = null;
            _phraseDialogIndex = 0;
            
            IsDialogEnded?.Invoke();
        }
    }
}
