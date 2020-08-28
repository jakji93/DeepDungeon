using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRune : MonoBehaviour
{
    public RuneConfig runeConfig;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyRune", runeConfig.GetLifeTime());
        transform.localScale = transform.localScale * runeConfig.GetSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyRune()
    {
        Destroy(gameObject);
    }

    public int GetCost()
    {
        return runeConfig.GetCost();
    }
}
