namespace Interaction
{
   public interface IInteractable
   {
      bool CanInteract();
      void InteractLeft();
      void InteractRight();
      void ExecuteActionLeft();
      void ExecuteActionRight();
      void LeftActionFinished();
      void RightActionFinished();
   }
}
