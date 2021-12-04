using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsScript : MonoBehaviour
{
    public static int bulletsValue = 5;
    Text bullets;

    // Start is called before the first frame update
    void Start()
    {
        bullets = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bullets.text = "BALAS: " + bulletsValue;
    }
}
