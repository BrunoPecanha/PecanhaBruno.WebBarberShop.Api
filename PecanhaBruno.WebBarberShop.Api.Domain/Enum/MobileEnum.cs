using System.ComponentModel;

namespace PecanhaBruno.WebBarberShop.Domain.Enum {
    public enum MobileEnum {
        [Description("iPhone")]
        iPhone = 1,
        [Description("Android")]
        Android,
        [Description("Sem Celular")]
        NoCel
    }
}
