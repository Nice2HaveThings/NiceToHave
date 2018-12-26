using NiceToHave.Utils;
using System;
using System.Collections.Generic;

namespace NiceToHave.Threading
{
    public partial class ThreadsafePromise<TResult>
    {
        private object _syncRoot = new object();

        private TResult _result;

        private Exception _rejection;

        private List<Action<TResult>> _resolveHandlers = new List<Action<TResult>>();

        private List<Action<Exception>> _rejectHandlers = new List<Action<Exception>>();

        public ThreadsafePromiseState State { get; private set; } = ThreadsafePromiseState.Pending;

        public void Resolve(TResult result)
        {
            lock (_syncRoot)
            {
                Require.Condition(() => State == ThreadsafePromiseState.Pending, "Promise is allready in final state.");

                _result = result;
                State = ThreadsafePromiseState.Resolved;

            }

            _resolveHandlers.ForEach(ResolveInternal);
        }

        public void Reject(Exception exception)
        {
            lock (_syncRoot)
            {
                Require.Condition(() => State == ThreadsafePromiseState.Pending, "Promise is allready in final state.");

                _rejection = exception;
                State = ThreadsafePromiseState.Rejected;
            }

            _rejectHandlers.ForEach(RejectInternal);
        }

        public void Done(Action<TResult> onResolved, Action<Exception> onRejected)
        {
            lock(_syncRoot)
            {
                if(State == ThreadsafePromiseState.Pending)
                {
                    _resolveHandlers.Add(onResolved);
                    _rejectHandlers.Add(onRejected);
                    return;
                }
            }

            if(State == ThreadsafePromiseState.Rejected)
            {
                RejectInternal(onRejected);
            }
            else
            {
                ResolveInternal(onResolved);
            }
        }

        private void RejectInternal(Action<Exception> handler)
        {
            try
            {
                handler(_rejection);
            }
            catch { }
        }

        private void ResolveInternal(Action<TResult> handler)
        {
            try
            {
                handler(_result);
            }
            catch { }
        }
    }
}
