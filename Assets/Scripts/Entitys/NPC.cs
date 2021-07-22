public class NPC : _Entity, IInteraction
{
    public void Interact()
    {
        
    }

    private void Start()
    {
        print(this.GetName());
    }

}
