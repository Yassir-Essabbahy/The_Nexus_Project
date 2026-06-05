using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public TextMeshProUGUI dialogueText;
    public AudioSource audioSource;

    void Awake() => Instance = this;

    public void PlayDialogue(DialogueLine[] lines)
    {
        StopAllCoroutines();
        StartCoroutine(RunLines(lines));
    }

    IEnumerator RunLines(DialogueLine[] lines)
{
    foreach (DialogueLine line in lines)
    {
        string localizedText = line.text.GetLocalizedString();
        Debug.Log(line.speakerName + ": " + localizedText);
        dialogueText.text = line.speakerName + ": " + localizedText;
        audioSource.clip = line.audio;
        if (line.audio != null) audioSource.Play();
        yield return new WaitForSeconds(line.duration);
    }
    dialogueText.text = "";
}
}