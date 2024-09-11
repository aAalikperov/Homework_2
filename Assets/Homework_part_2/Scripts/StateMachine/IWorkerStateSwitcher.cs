public interface IWorkerStateSwitcher 
{
   void SetState<T>() where T : IWorkerState;
}
