using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class AnimationInput
{
    public string animationPropertyName;
    public InputActionProperty action;
}

public class AnimateOnInput : MonoBehaviour
{
    public List<AnimationInput> animationInputs;
    public Animator animator;

    public InputActionReference[] inputActionProperty;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < inputActionProperty.Length; i++)
        {
            float val = inputActionProperty[i].action.ReadValue<float>();
            if (val > 0.7F)
            {
                print(i + "___" + val);
            }
        }


        foreach (var item in animationInputs)
        {
            float actionValue = item.action.action.ReadValue<float>();
            animator.SetFloat(item.animationPropertyName, actionValue);
        }
    }
}
