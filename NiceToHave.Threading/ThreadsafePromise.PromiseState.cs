namespace NiceToHave.Threading
{
    public partial class ThreadsafePromise<TResult>
    {
        public enum ThreadsafePromiseState
        {
            Pending,
            Rejected,
            Resolved
        }
    }
}
