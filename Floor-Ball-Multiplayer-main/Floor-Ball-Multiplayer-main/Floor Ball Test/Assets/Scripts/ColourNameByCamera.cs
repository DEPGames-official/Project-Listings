using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourNameByCamera : MonoBehaviour
{
    public CanvasScaler timerImageCanvasScaler;
    public Canvas timerImageCanvas;

    public Transform cameraTransform;

    public Canvas mainCanvas;

    public CanvasScaler mainCanvasScaler;

    public Transform playerTransform;

    Vector3 offset2;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
        offset2 = new Vector3(0f, +0.78f, +0.01F);

        
    }

    // Update is called once per frame
    private void Update()
    {
        rotateAroundCamera();

    }

    public void rotateAroundCamera()
    {
        if (playerTransform != null)
        {
            offset2 = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up) * offset2;
            this.transform.LookAt(cameraTransform);
            this.transform.position = playerTransform.position + offset2;

            this.mainCanvas.enabled = true;
            this.mainCanvasScaler.enabled = true;

            timerImageCanvas.enabled = true;
            timerImageCanvasScaler.enabled = true;

        }
        else if (playerTransform == null)
        {
            timerImageCanvas.enabled = false;
            timerImageCanvasScaler.enabled = false;

            this.mainCanvasScaler.enabled = false;
            this.mainCanvas.enabled = false;
        }

    }
}
