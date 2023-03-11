using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaySpace
{
    public class AnimatorManager : MonoBehaviour
    {
        public Animator anim;
        public void PlayTargetAnimation(string targetAnim, bool isInterracting)
        {
            anim.applyRootMotion = isInterracting;
            anim.SetBool("isInteracting", isInterracting);
            anim.CrossFade(targetAnim, 0.1f);
        }
    }
}