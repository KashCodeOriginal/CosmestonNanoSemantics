using UnityEngine;
using System.Collections.Generic;

public class Dialog : MonoBehaviour
{
    [SerializeField] private List<Phrase> _phrases = new List<Phrase>();

    public List<Phrase> Phrases => _phrases;
}