using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Añadir una Layer 'Targets' y desde el project settings -> physics hacer que no puedan
    //chocar consigo misma desde el matrix physics

    public List<GameObject> targetPrefabs;
    // Start is called before the first frame update

    public float spawnRate = 1.5f; //1,5 segundos
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    /// <summary>
    /// Instancia un objeto
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int idx = Random.Range(0, targetPrefabs.Count);

            //Instanciar una posicion aleatorio dentro de la lista de targetPrefabs rellenadas en Unity
            Instantiate(targetPrefabs[idx]);

            
        }
    }
}
