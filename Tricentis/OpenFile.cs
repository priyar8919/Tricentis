using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.AutomationInstructions.Dynamic.Values;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines;
using Tricentis.Automation.Engines.SpecialExecutionTasks;
using Tricentis.Automation.Engines.SpecialExecutionTasks.Attributes;

namespace TrainingSET
{
    [SpecialExecutionTaskName("AccessFile")]
    class BufferValue : SpecialExecutionTask
    {
        public BufferValue(Validator validator) : base(validator)
        {
        }

        public override ActionResult Execute(ISpecialExecutionTaskTestAction testAction)
        {
           IInputValue FilePath= testAction.GetParameterAsInputValue("FilePath", false);  //isOptional=true
            Process.Start(FilePath.Value);

            return new PassedActionResult("File Opened Successfully");
        }
    }
}
