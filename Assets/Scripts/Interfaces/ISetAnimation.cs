public interface ISetAnimation
{
    //Адаптер для передачи команд на переключение анимаций

    public void SetAnimation(string animName, bool Value);
    public void SetAnimation(string animName, float Value);
    public void SetAnimation(string animName, int Value);
}
