using System.ComponentModel;

namespace Presenters.Enum;

public enum UserType
{
    [Description("DOCTOR")]
    Doctor = 1,
    [Description("PATIENT")]
    Patient =2 
}