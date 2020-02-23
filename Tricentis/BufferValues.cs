using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.AutomationInstructions.Configuration;
using Tricentis.Automation.AutomationInstructions.Dynamic.Values;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.SpecialExecutionTasks;
using Tricentis.Automation.Engines.SpecialExecutionTasks.Attributes;
using Tricentis.Automation.Execution.Results;

namespace Training
{
    [SpecialExecutionTaskName("CustomBuffer")]
    class BufferValues : SpecialExecutionTaskEnhanced
    {
        public BufferValues(Validator validator) : base(validator)
        {
        }

        public override void ExecuteTask(ISpecialExecutionTaskTestAction testAction)
        {
            //  IParameter Parentparam =  testAction.GetParameter("BufferCredentials",false);

            //   IEnumerable<IParameter> Childparam = Parentparam.GetChildParameters("BufferCredentials");

            foreach (IParameter Param in testAction.Parameters)
            {
                if (Param.ActionMode == ActionMode.Input )
                {
                    IInputValue inputValue = Param.GetAsInputValue();
                    Buffers.Instance.SetBuffer(Param.Name, Param.GetAsInputValue().Value, false);
                    testAction.SetResultForParameter(Param, SpecialExecutionTaskResultState.Ok, string.Format("Buffer {0} set for value {1}", Param.Name, inputValue.Value));
                }
                else
                {
                    testAction.SetResultForParameter(Param, SpecialExecutionTaskResultState.Failed, string.Format("Fail"));
                }
            }

        }
    }
}
