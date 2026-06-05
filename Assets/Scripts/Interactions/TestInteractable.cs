using UnityEngine;

public class TestInteractable : Interactable
{
    public void OnInteract()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}