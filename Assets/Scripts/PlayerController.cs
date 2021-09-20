
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private PlayerMotor motor;

    public LayerMask movementMask;


    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }


    void Update()
    {
        // Move if left-mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                // Reset focus from any object
	        }
	    }

        // Focus on item if right-mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if we hit an interactable
                // If we did, set it as the focus
	        }
	    }
    }
}
