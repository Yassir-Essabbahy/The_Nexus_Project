using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float range = 2f;
    public Camera playerCamera;

    Interactable current;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray, range);

        Interactable found = null;

        foreach (RaycastHit hit in hits)
        {
            found = hit.collider.GetComponent<Interactable>()
                 ?? hit.collider.GetComponentInParent<Interactable>();
            if (found != null) break;
        }

        current = found;

        if (current != null && Input.GetKeyDown(KeyCode.E))
            current.OnInteract();

            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * range, Color.red);
    }
}