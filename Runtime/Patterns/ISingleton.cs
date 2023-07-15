namespace My.Core.Patterns
{
   public interface IBaseSingleton<T>
   {
      T Singleton { get; }
   }

   public interface ISingleton<TClass, TInterface> : IBaseSingleton<TInterface>
      where TClass : class, TInterface, ISingleton<TClass, TInterface>
   { }

   /// <summary>
   /// 
   /// </summary>
   public interface ISingleton<T> : IBaseSingleton<T>
        where T : ISingleton<T>
   { }
}