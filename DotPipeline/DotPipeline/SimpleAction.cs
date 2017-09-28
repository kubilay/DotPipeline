using System;

namespace DotPipeline
{
    public class SimpleAction : IAction
    {
        Func<bool> _action;
        bool result;

        public Func<bool> Action { get => _action; private set => _action = value; }
        public bool Result { get => result; set => result = value; }

        public SimpleAction(Func<bool> action)
        {
            Action = action;
        }

        public void Run()
        {
            result = Action.Invoke();
        }
    }
}
