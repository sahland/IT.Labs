using lab4_10.Models.Enums;

namespace lab4_10.Models.Interfaces
{
    public interface ILoader
    {
        event EventHandler oilLoaded;
        OilRigStatus LoadOil();
    }
}
