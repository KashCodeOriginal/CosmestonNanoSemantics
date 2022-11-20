using UnityEngine;

[System.Serializable]
public class Phrase
{
    [SerializeField] private string _phraseText;
    [SerializeField] private SpeakerType _speakerType;
    
    public string PhraseText => _phraseText;
    
    public SpeakerType Type => _speakerType;
}