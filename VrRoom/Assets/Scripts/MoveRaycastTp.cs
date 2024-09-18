using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRaycastTp : MonoBehaviour
{
    public Transform Player;
    public Camera MainCamera;
    private float PlayerHeight = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0))
            TryTeleport();
    }

    void TryTeleport()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
                Player.position = hit.point + Vector3.up * PlayerHeight;
            /*else
                Debug.Log("No tp through walls and doors.");*/
        }
    }
}
