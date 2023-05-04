using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtMouse : MonoBehaviour
{
    public float rotationalSpeed = 45f;
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // looking at this for help (https://gamedevbeginner.com/make-an-object-follow-the-mouse-in-unity-in-2d/#look_at_mouse_2D)
        Vector2 direction = mousePos - transform.position;

        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), rotationalSpeed * Time.deltaTime);

    }
}
