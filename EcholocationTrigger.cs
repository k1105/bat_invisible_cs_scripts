using UnityEngine;

[RequireComponent(typeof(MultiEcholocationController))]
public class EcholocationTrigger : MonoBehaviour
{
    private MultiEcholocationController controller;
    private Camera mainCamera;

    private void Start()
    {
        this.mainCamera = Camera.main;
        this.controller = this.GetComponent<MultiEcholocationController>();
    }

    private void Update()
    {
        // if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.mainCamera.ScreenPointToRay(Input.mousePosition), out var hitInfo))
        if (Input.GetMouseButtonDown(0))
        {
            this.controller.EmitCall(this.mainCamera.transform.position, 0.03f);
            // this.controller.EmitCall(hitInfo.point);
        }
    }
}