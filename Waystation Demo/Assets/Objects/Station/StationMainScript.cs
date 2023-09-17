using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationMainScript : MonoBehaviour
{
    private bool a;
    // Start is called before the first frame update
    void Start()
    {
        a = true;
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (a)
            {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(0, 1), 0.2f * Time.deltaTime);
                if (gameObject.transform.position == new Vector3(0, 1, 0))
                {
                    a = false;
                }
            }

            if (!a)
            {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(0, -1.5f), 0.2f * Time.deltaTime);
                if (gameObject.transform.position == new Vector3(0, -1.5f, 0))
                {
                    a = true;
                }
            }
        }
    }
}
