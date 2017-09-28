using System.Collections.Generic;

namespace DotPipeline
{
    public class Job : List<IAction>, IAction
    {
        public Job() : base()
        {

        }

        bool result;

        public bool Result { get => result; private set => result = value; }

        public void Run()
        {
            foreach (IAction action in this)
            {
                action.Run();
                if (!action.Result)
                {
                    result = false;
                    break;
                }
            }
        }
    }
}
