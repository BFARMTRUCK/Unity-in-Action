using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
         if (enemy == null)
         {
              enemy = Instantiate(enemyPrefab) as GameObject;
              float angle = Random.Range(0, 360);
              enemy.transform.Rotate(0, angle, 0);
              float height = Random.Range(0.1f, 5);
              enemy.transform.localScale = new Vector3(enemy.transform.localScale.x, height, enemy.transform.localScale.z);
              enemy.transform.position = new Vector3(0, height/2, 0);
              Color randomColor = Random.ColorHSV();
              Renderer renderer = enemy.GetComponent<Renderer>();
              if (renderer != null)
              {
                  renderer.material.color = randomColor;
              }
         }
        
    }
}
