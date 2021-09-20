using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rover : MonoBehaviour
{
    [SerializeField]
    private Vector3 position1;

    [SerializeField]
    private Vector3 position2;

    [SerializeField]
    private float speed = 1.0f;


    void Update()
    {
        // From https://answers.unity.com/questions/690884/how-to-move-an-object-along-x-axis-between-two-poi.html
        transform.position = Vector3.Lerp(position1, position2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(position1, 0.1f);
        Gizmos.DrawSphere(position2, 0.1f);
    }
}
