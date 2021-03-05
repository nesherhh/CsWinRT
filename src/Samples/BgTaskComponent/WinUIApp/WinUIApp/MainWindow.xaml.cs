using Microsoft.UI.Xaml;
using Windows.ApplicationModel.Background;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var taskRegistered = false;
            var exampleTaskName = "ToastBgTask";

            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == exampleTaskName)
                {
                    taskRegistered = true;
                    break;
                }
            }

            if (!taskRegistered)
            {
                var builder = new BackgroundTaskBuilder
                {
                    Name = exampleTaskName,
                    TaskEntryPoint = "BgTaskComponent.ToastBgTask"
                };
                builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
                builder.Register();
            }
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
        }
    }
}
