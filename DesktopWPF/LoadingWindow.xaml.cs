using System;

using System.Threading.Tasks;
using System.Windows;




namespace DesktopWPF
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>

    public partial class LoadingWindow : Window, IDisposable
    {
        public Action Worker { get; set; }

        public LoadingWindow(Action worker)
        {
            InitializeComponent();

            if (worker == null)
            {
                throw new ArgumentNullException(nameof(worker));
            }

            Worker = worker;
        }

        protected override async void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            await Task.Run(Worker);


            Dispose();
        }

        public void Dispose()
        {
            Close();

        }
    }
}
