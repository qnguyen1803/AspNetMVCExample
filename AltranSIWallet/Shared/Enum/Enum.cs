using System.ComponentModel;

namespace AltranSIWallet.Shared.Enum
{
    public enum ELevels
    {
        [Description("Consultant Junior")]
        Junior = 0,

        [Description("Consultant")]
        Medium = 1,

        [Description("Advanced Consultant")]
        Advanced = 2,

        [Description("Senior Consultant")]
        Senior = 3, 
    }
}