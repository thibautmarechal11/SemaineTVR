using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using PDollarGestureRecognizer;
using System.IO;

public class MovementRecognizerV2 : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputTheshold = 0.1f;
    public Transform movementSource;

    public float newPositionThresholdDistance = 0.05f;
    public GameObject debugCubePrefab;
    public bool creationMode = true;
    public string newGestureName;

    private List<Gesture> trainingSet = new List<Gesture>();
    private bool isMoving = false;
    private List<Vector3> positionsList = new List<Vector3>();

    #region Audio FMOD
    public FMOD.Studio.EventInstance castSound;
    #endregion

    private void Start()
    {
        castSound = FMODUnity.RuntimeManager.CreateInstance("event:/Cast_Loop");

        TextAsset[] gesturesXml = Resources.LoadAll<TextAsset>("GestureSet/CustomGestureSet");
        foreach (TextAsset gestureXml in gesturesXml)
            trainingSet.Add(GestureIO.ReadGestureFromXML(gestureXml.text));

    }
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputTheshold);

        //Start the movement
        if (!isMoving && isPressed)
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

        isMoving = true;

        positionsList.Clear();
        positionsList.Add(movementSource.position);

        castSound.start();

        if (debugCubePrefab)
            Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
    }

    void EndMovement()
    {
        TextDebug.Instance.Text("End Movement");
        isMoving = false;

        castSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        //Create the gesture from the position list
        Point[] pointArray = new Point[positionsList.Count];

        for (int i = 0; i < positionsList.Count; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionsList[i]);
            pointArray[i] = new Point(screenPoint.x, screenPoint.y, 0);
        }

        Gesture newGesture = new Gesture(pointArray);

        //Add a new gesture to training set
        if (creationMode)
        {
            newGesture.Name = newGestureName;
            trainingSet.Add(newGesture);

            string fileName = Application.persistentDataPath + "/" + newGestureName + ".xml";
            GestureIO.WriteGesture(pointArray, newGestureName, fileName);

        }
        //Recognize
        else
        {
            Result result = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());
            //result.GestureClass > Class Gesture du r?sultat STRING
            //result.Score > Niveau de pr?cision du mouvement de 0 ? 1 (0.9 je pense c'est good)
            MovementRecognisionDebug.Instance.Text(result.GestureClass + " " + result.Score);
            
        }
    }


    void UpdateMovement()
    {
        TextDebug.Instance.Text("Update Movement");

        Vector3 lastPosition = positionsList[positionsList.Count - 1];
        if (Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position);

            if (debugCubePrefab)
                Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
        }
    }

}
