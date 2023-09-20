using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlatform : MonoBehaviour
{
    private Quaternion labyrinthRotationStartingRotation;
    [SerializeField] private GameObject platform;
    [SerializeField] private float speed;

    [SerializeField] private float clampLabyrinth;
    
    private PlayerInputs playerInputs;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
        labyrinthRotationStartingRotation = transform.rotation;
    }

    public void ResetPlatform()
    {
        platform.transform.rotation = labyrinthRotationStartingRotation;
    }
    private void TiltLabyrinth(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        Vector3 correctRotation = new Vector3(-value.y, platform.transform.rotation.y, value.x);
        correctRotation.x = Mathf.Clamp(correctRotation.x, -clampLabyrinth, clampLabyrinth);
        correctRotation.z = Mathf.Clamp(correctRotation.z, -clampLabyrinth, clampLabyrinth);
        platform.transform.Rotate(correctRotation.normalized * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        playerInputs.Enable();
        playerInputs.PlayerTiltLabyrinth.TiltLabyrinth.performed += TiltLabyrinth;
    }

    private void OnDisable()
    {
        playerInputs.Disable();
        playerInputs.PlayerTiltLabyrinth.TiltLabyrinth.performed -= TiltLabyrinth;
    }
}
