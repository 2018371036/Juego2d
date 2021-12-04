using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Bullet"))
        {
            ScoreScript.scoreValue += 100;
            BulletsScript.bulletsValue += 2;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
