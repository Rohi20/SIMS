namespace SIMSWeb.Model.ViewModels.Common
{
    public class MetricsViewModel
    {
        public string Label {  get; set; }
        public double Value { get; set; }
        public string BgColor {  get; set; }
        public string? ActionName { get; set; }
        public string? ControllerName { get; set; }
    }
}
