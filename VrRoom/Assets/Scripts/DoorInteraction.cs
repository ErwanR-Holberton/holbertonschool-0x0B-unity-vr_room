using UnityEngine;
public class DoorInteraction : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;
    void Start()
    {
        animator = GetComponent<Animator>();  // Ensure the door has an Animator component
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is for the left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 5f))  // Adjust ray distance as needed
            {
                Transform target = hit.transform;
                if (target.IsChildOf(transform))
                    ToggleDoor();
            }
        }
    }
    private void ToggleDoor()
    {
        isOpen = !isOpen;  // Toggle the state
        animator.SetBool("character_nearby", isOpen);  // Change the 'isOpen' parameter in the Animator
    }
}