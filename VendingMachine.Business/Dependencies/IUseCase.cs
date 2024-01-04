namespace iQuest.VendingMachine.Business.Dependencies
{
    public interface IUseCase
    {
        public virtual void Execute()
        {
            
        }

        public virtual void Execute(float price)
        {

        }
    }
}