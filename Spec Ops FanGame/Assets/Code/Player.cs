using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public InputManager im;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 euler = transform.rotation.eulerAngles;
        Vector2 update = im.getInputForCamera(2.5f, 1f, false, true, true, true);
        transform.rotation = Quaternion.Euler(euler.x + update.x, euler.y + update.y, euler.z);
    }



}
