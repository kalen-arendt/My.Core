namespace My.Core.Patterns
{

   public interface ISingletonFactory<T>
   {
      T GetSingleton { get; }
   }
}