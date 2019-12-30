using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    void Update()
    {
        if (!GameController.instance.GameOver)
        {
            RotateWithMouse();
        }
    }

    //rotate player com a posição do mouse
    private void RotateWithMouse()
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouseScreenPosition.y - this.transform.position.y, mouseScreenPosition.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        if (AngleDeg >= 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }
    }
}
