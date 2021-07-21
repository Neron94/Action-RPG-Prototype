public class NPC : _Entity, IInteraction
{
    public void Interact()
    {
        print("Hi my name is" + " " + this.GetName());
    }

    private void Start()
    {
        print(this.GetName());
    }

}
