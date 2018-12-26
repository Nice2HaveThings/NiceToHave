using System;
using System.Collections.Generic;
using System.Linq;

namespace NiceToHave.Desicion.States
{
    public class State<TType>
    {
        private Statemachine<TType> _stateMachine;

        private List<Transition<TType>> _transitions = new List<Transition<TType>>();

        public  bool IsFinal { get; internal set; }

        public string Identifier { get; }

        public State(string identifier, Statemachine<TType> stateMachine)
        {
            Identifier = identifier;
            _stateMachine = stateMachine;
        }

        public State<TType> TransitToState(string targetIdentifier, Predicate<TType> condtion)
        {
            return TransitToState(targetIdentifier, condtion, (element) => { });
        }

        public State<TType> TransitToState(string targetIdentifier, Predicate<TType> condition, Action<TType> transformation)
        {
            _transitions.Add(new Transition<TType>(_stateMachine.GetOrCreateState(targetIdentifier), condition, transformation));
            return this;
        }

        public void TransitToEnd()
        {
            TransitToEnd((element) => true, (element) => { });
        }

        public void TransitToEnd(Predicate<TType> condition)
        {
            TransitToEnd(condition, (element) => { });
        }

        public void TransitToEnd(Predicate<TType> condition, Action<TType> transformation)
        {
            _transitions.Add(new Transition<TType>(_stateMachine.FinalState, condition, transformation));
        }

        internal void Execute(TType element)
        {
            if(IsFinal)
            {
                return;
            }

            var transition = _transitions.FirstOrDefault(t => t.Condition(element));
            if(transition == null)
            {
                throw new InvalidOperationException($"Not condition for status {Identifier} found, no transaction possible.");
            }

            transition.Transformation(element);
            transition.TargetState.Execute(element);
        }
    }
}
