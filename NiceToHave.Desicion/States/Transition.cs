using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceToHave.Desicion.States
{
    internal class Transition<TType>
    {
        public State<TType> TargetState;

        public Predicate<TType> Condition;

        public Action<TType> Transformation;

        public Transition(State<TType> targetState, Predicate<TType> condition, Action<TType> transformation)
        {
            TargetState = targetState;
            Condition = condition;
            Transformation = transformation;
        }
    }
}
