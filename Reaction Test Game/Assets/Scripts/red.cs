using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour
{
    // Start is called before the first frame update
    private float lt;

    void Start()
    {
        lt = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        lt += Time.deltaTime;
        if (lt > 0.6f)
        {
            Destroy(this.gameObject);
        }
    }
}
