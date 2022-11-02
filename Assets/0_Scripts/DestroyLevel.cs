using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevel : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyTheLevel());
    }

    IEnumerator DestroyTheLevel()
	{
        yield return new WaitForSeconds(30);
        Destroy(this.gameObject);
	}
}
