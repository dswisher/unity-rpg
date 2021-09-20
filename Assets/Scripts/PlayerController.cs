
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;

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

                RemoveFocus();
	        }
	    }

        // Focus on item if right-mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
		        }
	        }
	    }
    }


    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        { 
            if (focus != null)
            { 
				focus.OnDefocused();
	        }

			focus = newFocus;
			motor.FollowTarget(newFocus);
	    }

        newFocus.OnFocused(transform);
    }


    void RemoveFocus()
    {
        if (focus != null)
        { 
			focus.OnDefocused();
	    }

        focus = null;
        motor.StopFollowingTarget();
    }
}
