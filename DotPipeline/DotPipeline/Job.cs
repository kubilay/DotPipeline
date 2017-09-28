using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPipeline
{
    public class Job : List<IAction>
    {
        public Job() : base()
        {

        }

        public bool Process()
        {
            bool retVal = true;
            foreach (IAction action in this)
            {
                action.Run();
                if (!action.Result)
                {
                    retVal = false;
                    break;
                }
            }
            return retVal;
        }
    }
}
