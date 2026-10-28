using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;  // «Ã⁄· Â–« «·„ €Ì— public · ⁄ÌÌ‰Â ›Ì Unity Editor

    // Start is called before the first frame update
    void Start()
    {
        if (logic == null)
        {
            logic = FindObjectOfType<LogicScript>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
        }
    }
}
