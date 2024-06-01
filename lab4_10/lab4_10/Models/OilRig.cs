using lab4_10.Models.Enums;

namespace lab4_10.Models
{
    public class OilRig
    {
        private Int32 _maxOil;
        private Int32 _oilNow;
        private Int32 _oilInSecond;

        private Mechanic _mechanic;
        private Loader _loader;
        private OilRigStatus _status;

        public event EventHandler<Int32> _oilExtracted;
        public event EventHandler _oilSent;
        public event EventHandler<OilRigStatus> _statusChanged;

        private Random _random;

        public Int32 _allOilExtract { get; private set; }

        public OilRig()
        {
            _maxOil = 100;
            _oilNow = 0;
            _oilInSecond = 25;
            _allOilExtract = 0;

            _mechanic = new Mechanic();
            _loader = new Loader();
            _status = OilRigStatus.Normal;

            _random = new Random();
        }

        public void StartDrilling()
        {
            while (true)
            {
                if (_random.Next(0, 100) < 10)
                {
                    _status = OilRigStatus.Fire;
                    OnStatusChanged(_status);
                    Thread.Sleep(4000);
                    _oilNow = 0;
                    _status = _mechanic.FixPlatformFire();
                    OnStatusChanged(_status);
                    continue;
                }

                _oilNow += _oilInSecond;

                if (_oilNow >= _maxOil)
                {
                    _status = _loader.LoadOil();
                    OnStatusChanged(_status);
                    _allOilExtract += _maxOil;
                    _oilNow = 0;
                    Thread.Sleep(3000);
                    _status = OilRigStatus.Normal;
                    OnStatusChanged(_status);
                    OnOilExtracted(_allOilExtract);
                }
            }
        }

        protected virtual void OnOilExtracted(Int32 oilVolume)
        {
            _oilExtracted?.Invoke(this, oilVolume);
        }

        protected virtual void OnStatusChanged(OilRigStatus newStatus)
        {
            _statusChanged?.Invoke(this, newStatus);
        }

        public int getOilExtract()
        {
            return _allOilExtract;
        }

    }
}
