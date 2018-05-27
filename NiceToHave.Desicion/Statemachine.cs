using NiceToHave.Desicion.States;
using NiceToHave.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceToHave.Desicion
{
    public class Statemachine<TType>
    {
        private const string INITIAL_STATE_NAME = "InitialState";

        private const string FINAL_STATE_NAME = "FinalState";

        private Dictionary<string, State<TType>> _flatStateList = new Dictionary<string, State<TType>>();

        internal State<TType> FinalState { get; }

        public State<TType> InitialiState { get; }

        public Statemachine()
        {
            Require.IsComplex(typeof(TType), "Statemachine is only provides for complex referenztypes.");

            InitialiState = new State<TType>(INITIAL_STATE_NAME, this);
            FinalState = new State<TType>(FINAL_STATE_NAME, this)
            {
                IsFinal = true
            };
            _flatStateList.Add(INITIAL_STATE_NAME, InitialiState);
            _flatStateList.Add(FINAL_STATE_NAME, FinalState);
        }

        public void Execute(TType element)
        {
            InitialiState.Execute(element);
        }

        public State<TType> GetState(string identifier)
        {
            return _flatStateList[identifier];
        }

        internal State<TType> GetOrCreateState(string identifier)
        {
            if(!_flatStateList.ContainsKey(identifier))
            {
                _flatStateList.Add(identifier, new State<TType>(identifier, this));
            }

            return GetState(identifier);
        }
    }
}
