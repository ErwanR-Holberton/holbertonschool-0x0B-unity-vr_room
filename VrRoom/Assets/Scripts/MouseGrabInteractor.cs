using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MouseGrabInteractor : MonoBehaviour
{
    public Camera mainCamera;
    public float maxGrabDistance = 10f;
    private XRBaseInteractable grabbedObject;

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            TryGrabObject();
        }
        else if (Input.GetMouseButtonUp(0) && grabbedObject != null)
        {
            ReleaseObject();
        }
        else if (grabbedObject != null)
        {
            // Move the grabbed object with the mouse
            MoveGrabbedObject();
        }
    }

    private void TryGrabObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, maxGrabDistance))
        {
            XRGrabInteractable grabInteractable = hit.collider.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabbedObject = grabInteractable;
                grabbedObject.transform.SetParent(mainCamera.transform);
            }
        }
    }

    private void ReleaseObject()
    {
        grabbedObject.transform.SetParent(null);
        grabbedObject = null;
    }

    private void MoveGrabbedObject()
    {
        // Ensure the grabbed object moves with the camera/mouse
        // (You can modify this based on your specific movement needs)
        grabbedObject.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 2f;
    }
}
