using UnityEngine;

// Система управления анимацией
public class AnimationSystem : MySystem, ISetAnimation
{
    [SerializeField] Animator myAnimator;

    private void Awake()
    {
        myAnimator = transform.GetComponent<Animator>();
        if (myAnimator == null) Debug.LogError("No animator on this object"); // Проверка аниметора на обьекте
    }


    public void SetAnimation(string animName, bool Value)
    {
        if (myAnimator != null) myAnimator.SetBool(animName, Value);
    }
    public void SetAnimation(string animName, float Value)
    {
        if (myAnimator != null) myAnimator.SetFloat(animName, Value);
    }
    public void SetAnimation(string animName, int Value)
    {
        if (myAnimator != null) myAnimator.SetInteger(animName, Value);
    }
}
