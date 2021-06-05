using Sensors.View; 

namespace Sensors.ViewModel
{
    public class MainWindowVM
    {
        private SpeedometerVM _SpeedometerVM;
        public SpeedometerVM SpeedometerVM
        {
            get { return _SpeedometerVM; }
        }

        private SteeringWheelVM _SteeringWheelVM;
        public SteeringWheelVM SteeringWheelVM
        {
            get { return _SteeringWheelVM; }
        }
        
        public MainWindowVM(MainWindow window)
        {
            this._SpeedometerVM = new SpeedometerVM(window); 
            this._SteeringWheelVM = new SteeringWheelVM(window); 
        }
    }
}