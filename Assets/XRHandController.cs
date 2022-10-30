using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum HandType
{
    Left,
    Right
}

public class XRHandController : MonoBehaviour
{
    public HandType handType;
    public float thumbMoveSpeed = 0.1f;

    private Animator animator;
    private InputDevice inputDevice;

    private float indexValue;
    private float thumbValue;
    private float threeFingersValue;
    
    public bool isMine = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        inputDevice = GetInputDevice();
    }

    // Update is called once per frame
    void Update()
    {
        // if (inputDevice != null)
        //     AnimateHand();
        if (isMine) {
            AnimateHand();
        }
        
        // AnimateGrab();
    }

    InputDevice GetInputDevice()
    {
        // InputDeviceCharacteristics controllerCharacteristic = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left, leftHandedControllers;
        InputDeviceCharacteristics controllerCharacteristic = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice;
        // InputDeviceCharacteristics leftHandedControllers;


        if (handType == HandType.Left)
        {
            controllerCharacteristic = controllerCharacteristic | InputDeviceCharacteristics.Left;
        }
        else
        {
            controllerCharacteristic = controllerCharacteristic |  InputDeviceCharacteristics.Right;
        }

        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, inputDevices);
        
        // InputDeviceCharacteristics leftTrackedControllerFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left, leftHandedControllers;
        // InputDevices.GetDevicesWithCharacteristics(leftTrackedControllerFilter, inputDevices);
        
        return inputDevices[0];
    }

    void AnimateHand()
    {
        inputDevice.TryGetFeatureValue(CommonUsages.trigger, out indexValue);
        inputDevice.TryGetFeatureValue(CommonUsages.grip, out threeFingersValue);

        inputDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched);
        inputDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched);

        if (primaryTouched || secondaryTouched)
        {
            thumbValue += thumbMoveSpeed;
        }
        else
        {
            thumbValue -= thumbMoveSpeed;
        }
        thumbValue = Mathf.Clamp(thumbValue, 0, 1);

        if (handType == HandType.Left)
        {
           // Debug.Log("indexValue" + indexValue.ToString());
        animator.SetFloat("Index", indexValue);
        animator.SetFloat("ThreeFingers", threeFingersValue);
        animator.SetFloat("Thumb", thumbValue);
        }
        else if (handType == HandType.Right) {
        // Debug.Log("indexValue" + indexValue.ToString());
        animator.SetFloat("Index_Right", indexValue);
        animator.SetFloat("ThreeFingers_Right", threeFingersValue);
        animator.SetFloat("Thumb_Right", thumbValue);
        }
        
    }

    public void AnimateGrab() {
            Debug.Log("XRHandController AnimateGrab() Called");

         if (handType == HandType.Left)
        {
           // Debug.Log("indexValue" + indexValue.ToString());
            animator.SetFloat("Index", 1);
            animator.SetFloat("ThreeFingers", 1);
            animator.SetFloat("Thumb", 1);
        }
        else if (handType == HandType.Right) {
        // Debug.Log("indexValue" + indexValue.ToString());
            animator.SetFloat("Index_Right", 1);
            animator.SetFloat("ThreeFingers_Right", 1);
            animator.SetFloat("Thumb_Right", 1);
        }
    }
    public void AnimateRelease() {
        if (handType == HandType.Left)
        {
           // Debug.Log("indexValue" + indexValue.ToString());
            animator.SetFloat("Index", 0);
            animator.SetFloat("ThreeFingers", 0);
            animator.SetFloat("Thumb", 0);
        }
        else if (handType == HandType.Right) {
        // Debug.Log("indexValue" + indexValue.ToString());
            animator.SetFloat("Index_Right", 0);
            animator.SetFloat("ThreeFingers_Right", 0);
            animator.SetFloat("Thumb_Right", 0);
        }
    }
}
