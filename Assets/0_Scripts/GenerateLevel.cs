using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject newLevel;
    public float zPos = 0;
    private bool cretaingLevel = false;
    
    

    
    void Update()
    {
		if (cretaingLevel == false)
		{
            cretaingLevel = true;
            StartCoroutine(GenerateTheLevel());
            
        }
    }

    IEnumerator GenerateTheLevel()
	{
        Instantiate(newLevel, new Vector3(5, (float)3.101985, zPos), Quaternion.identity);
        zPos += (float)267.6;
        yield return new WaitForSeconds(20);
        cretaingLevel = false;
    }
}
