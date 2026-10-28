using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -16;

    // Update is called once per frame
    void Update()
    {
        //  Õ—Ìﬂ «·√⁄„œ… ‰ÕÊ «·Ì”«—
        transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);

        //  œ„Ì— «·⁄„Êœ ≈–« Œ—Ã „‰ «·‘«‘…
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
