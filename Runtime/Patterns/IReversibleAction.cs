using System.Collections.Generic;

namespace My.Core.Patterns
{
   public interface IReversibleAction
   {
      void Redo ();
      void Undo ();
   }

   public class ActionManagerSingletonFactory : ISingletonFactory<ActionManager>
   {
      private static ActionManager instance;

      public ActionManager GetSingleton => instance ??= new ActionManager();
   }
      
   public class ActionManager
   {
      private readonly Stack<IReversibleAction> undoStack;
      private readonly Stack<IReversibleAction> redoStack;

      public ActionManager ()
      {
         undoStack = new Stack<IReversibleAction>();
         redoStack = new Stack<IReversibleAction>();
      }

      // Add a new action to the undo stack
      public void AddAction (IReversibleAction action)
      {
         undoStack.Push(action);
         redoStack.Clear();
      }

      // Perform an undo operation
      public void Undo ()
      {
         if (undoStack.Count > 0)
         {
            IReversibleAction action = undoStack.Pop();
            action.Undo();
            redoStack.Push(action);
         }
      }

      // Perform an redo operation
      public void Redo ()
      {
         if (redoStack.Count > 0)
         {
            IReversibleAction action = redoStack.Pop();
            action.Redo();
            undoStack.Push(action);
         }
      }

      // Clear all actions from the stack
      public void ClearActions ()
      {
         undoStack.Clear();
      }
   }
}
