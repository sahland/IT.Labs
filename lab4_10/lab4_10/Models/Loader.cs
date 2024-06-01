using lab4_10.Models.Enums;
using lab4_10.Models.Interfaces;

namespace lab4_10.Models
{
    public class Loader : ILoader
    {
        public event EventHandler oilLoaded;

        public OilRigStatus LoadOil()
        {
            OnOilLoaded();
            return OilRigStatus.LoadingOil;
        }

        protected virtual void OnOilLoaded()
        {
            oilLoaded?.Invoke(this, EventArgs.Empty);
        }
    }
}
