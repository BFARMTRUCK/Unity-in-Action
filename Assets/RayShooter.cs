using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    private Vector3 hitCoordinates;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int cursorSize = 24;
        float cursorPosX = cam.pixelWidth / 2 - cursorSize / 4;
        float cursorPosY = cam.pixelHeight / 2 - cursorSize / 2;
        GUI.Label(new Rect(cursorPosX, cursorPosY, cursorSize, cursorSize), "*");

        // Display hit coordinates next to the cursor
        if (Event.current.type == EventType.Repaint)
        {
            GUIStyle style = GUI.skin.label;
            style.normal.textColor = Color.black;
            GUI.Label(new Rect(cursorPosX + cursorSize, cursorPosY, 200, 20), "Hit Point: " + hitCoordinates.ToString(), style);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    hitCoordinates = hit.point; // Store hit coordinates
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
