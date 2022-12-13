using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputTheshold = 0.1f;
    public Transform movementSource;

    public float newPositionThresholdDistance = 0.05f;
    public GameObject debugCubePrefab;

    private bool isMoving = false;
    private List<Vector3> positionsList = new List<Vector3>();


    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputTheshold);
   
        //Start the movement
        if(!isMoving && isPressed)
        {
            StartMovement();
        }
        //Ending the movement
        else if (isMoving && !isPressed)
        {
            EndMovement();
        }
        //Updating the movement
        else if (isMoving && isPressed)
        {
            UpdateMovement();
        }
    }

    void StartMovement()
    {
        TextDebug.Instance.Text("Start Movement");

        isMoving= true;
        positionsList.Clear();
        positionsList.Add(movementSource.position);

        if(debugCubePrefab) 
            Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity),3);
    }

    void EndMovement()
    {
        TextDebug.Instance.Text("End Movement");
        isMoving = false;
    }

    void UpdateMovement()
    {
        TextDebug.Instance.Text("Update Movement");

        Vector3 lastPosition = positionsList[positionsList.Count - 1];  
        if(Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position);

            if (debugCubePrefab)
                Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
        }
    }

}
