using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRune : MonoBehaviour
{
    public GameObject rune1;
    public GameObject rune2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ActiveRune(rune1);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            ActiveRune(rune2);
        }
    }

    private void ActiveRune(GameObject rune)
    {
        var currentRunes = GameObject.FindWithTag(rune.tag);
        if (currentRunes != null) Destroy(currentRunes);
        Instantiate(rune, transform.position, Quaternion.identity);
    }
}
