using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipePairPrefab;   // Prefab íÍÊæí Úáì ÇáÃÚãÏÉ ÇáÚáæíÉ æÇáÓİáíÉ ãÚğÇ
    public float spawnRate = 2f;  // ãÚÏá ÊæáíÏ ÇáÃÚãÏÉ
    private float timer = 0f;  // ãæŞÊ áÖÈØ ÊæŞíÊ ÇáÊæáíÏ
    public float moveSpeed = 5f;  // ÓÑÚÉ ÍÑßÉ ÇáÃÚãÏÉ Åáì ÇáíÓÇÑ
    public float minY = -2.5f;  // ÇáÍÏ ÇáÃÏäì ááÇÑÊİÇÚ Úáì ÇáãÍæÑ Y
    public float maxY = 2.5f;  // ÇáÍÏ ÇáÃŞÕì ááÇÑÊİÇÚ Úáì ÇáãÍæÑ Y
    public float heightOffset = 3f;  // ÊÍÏíÏ ÇáÍÏ ÇáÚÔæÇÆí ááÇÑÊİÇÚ

    void Start()
    {
        // ÊæáíÏ ÇáÃÚãÏÉ İæÑ ÈÏÁ ÇááÚÈÉ
        SpawnPipes();
    }

    void Update()
    {
        // ÊÍŞŞ ãä ÇáãæŞÊ áÊæáíÏ ÃÚãÏÉ ÌÏíÏÉ ÈäÇÁğ Úáì ãÚÏá ÇáÊæáíÏ
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipes();
            timer = 0f;
        }

        // ÊÍÑíß ÌãíÚ ÇáÃÚãÏÉ ÇáãæÌæÏÉ Åáì ÇáíÓÇÑ
        MovePipesLeft();
    }

    void SpawnPipes()
    {
        // ÊæáíÏ ÇÑÊİÇÚ ÚÔæÇÆí Öãä ÇáÍÏæÏ ÇáãÍÏÏÉ
        float randomHeight = Random.Range(minY, maxY);

        // ÊæáíÏ `Prefab` ÇáÃÚãÏÉ ÇáÚáæíÉ æÇáÓİáíÉ ãÚğÇ æÖÈØ ÇÑÊİÇÚå ÇáÚÔæÇÆí
        Vector3 pipePosition = new Vector3(transform.position.x, randomHeight, 0);
        Instantiate(pipePairPrefab, pipePosition, Quaternion.identity);
    }

    void MovePipesLeft()
    {
        // ÇáÚËæÑ Úáì ÌãíÚ ÇáÃÚãÏÉ æÊÍÑíßåÇ Åáì ÇáíÓÇÑ
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");  // ÊÃßÏ ãä Ãä ÌãíÚ ÇáÃÚãÏÉ Êãáß ÇáÜ Tag "Pipe"
        foreach (GameObject pipe in pipes)
        {
            pipe.transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            // ÊÏãíÑ ÇáÃÚãÏÉ ÇáÊí ÊÎÑÌ ãä ÇáÔÇÔÉ
            if (pipe.transform.position.x < -15)  // íÚÊãÏ åĞÇ Úáì ÃÈÚÇÏ ÇáÔÇÔÉ
            {
                Destroy(pipe);
            }
        }
    }
}
