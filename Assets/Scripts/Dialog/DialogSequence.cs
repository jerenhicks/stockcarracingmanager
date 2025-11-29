using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog Sequence", menuName = "Dialog/Dialog Sequence")]
public class DialogSequence : ScriptableObject
{
    public List<DialogEntry> entries = new List<DialogEntry>();
}
