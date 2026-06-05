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
        var op = line.text.GetLocalizedStringAsync();
        yield return op;

        string localizedText = op.Result;

        dialogueText.text = line.speakerName + ": " + localizedText;

        if (line.audio != null)
        {
            audioSource.clip = line.audio;
            audioSource.Play();

            yield return new WaitWhile(() => audioSource.isPlaying);
        }
        else
        {
            yield return new WaitForSeconds(line.duration);
        }
    }

    dialogueText.text = "";
}
}