using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    public float increaser = 20f;
    private void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / increaser;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5) Destroy(gameObject);    
    }
}
