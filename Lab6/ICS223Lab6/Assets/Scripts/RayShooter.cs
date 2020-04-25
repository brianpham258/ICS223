using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera camera;
    public int aimSize = 16;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                // is object our enemy ?
                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    // visually indicate where was a hit
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 hitPosition) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.position = hitPosition;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }

    void OnGUI() {
        GUIStyle style = new GUIStyle();
        style.fontSize = aimSize;

        // find the centre of the camera view and adjust for asterisk
        float posX = camera.pixelWidth / 2 - aimSize / 4;
        float posY = camera.pixelHeight / 2 - aimSize / 2;

        GUI.Label(new Rect(posX, posY, aimSize, aimSize), "O", style);

    }
}
