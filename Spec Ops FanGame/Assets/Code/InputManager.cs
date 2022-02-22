using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {


    public bool mouseControl;

   // Vector3 lastMousePos;
    
    
    // Start is called before the first frame update
    void Start() {
        //lastMousePos = Input.mousePosition;
        if (mouseControl)
            Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        if (mouseControl)
            Cursor.lockState = CursorLockMode.Locked;
    }

    public Vector2 getMouseDelta () {
        //Vector3 returnVector = lastMousePos - Input.mousePosition;
        //lastMousePos = Input.mousePosition;
        return new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
    }

    public Vector2 getArrowDirection (float scale, bool invertv, bool inverth) {
        float inversionv = (invertv) ? -1 : 1;
        float inversionh = (inverth) ? -1 : 1;
        float h = 0;
        float v = 0;
        if (Input.GetKey(KeyCode.UpArrow)) {
            v = scale;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            v = -scale;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            h = scale;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            h = -scale;
        }
        v *= inversionv;
        h *= inversionh;
        return new Vector2(v, h);
    }

    public Vector2 getInputForCamera (float scale, float arrowScale, bool invertv, bool inverth, bool iav, bool iah) {
        float inversionv = (inverth) ? -1 : 1;
        float inversionh = (invertv) ? -1 : 1;
        if (mouseControl) {
            Vector2 m = getMouseDelta();
            return new Vector2(m.x * scale * inversionv, m.y * scale * inversionh);
        } else {
            return getArrowDirection(arrowScale, iav, iah);
        }
    }

}
