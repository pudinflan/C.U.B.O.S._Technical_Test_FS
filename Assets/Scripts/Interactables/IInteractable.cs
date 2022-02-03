namespace Interactables
{
   public interface IInteractable
   {
      bool CanBeInteracted();
      void InteractLeft();
      void InteractRight();
      void ExecuteActionLeft();
      void ExecuteActionRight();
      void LeftActionFinished();
      void RightActionFinished();
   }
}
