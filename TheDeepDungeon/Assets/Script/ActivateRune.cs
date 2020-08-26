using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRune : MonoBehaviour
{
    public GameObject rune1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            var currentRunes = GameObject.FindWithTag(rune1.tag);
            if (currentRunes != null) Destroy(currentRunes);
            Instantiate(rune1, transform.position, Quaternion.identity);
        }
    }
}
