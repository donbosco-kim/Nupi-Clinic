using Nupi_Clinic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nupi_Clinic.View
{
    /// <summary>
    /// Interaction logic for UpdatePatientView.xaml
    /// </summary>
    public partial class UpdatePatientView : Window
    {
        public UpdatePatientView()
        {
            InitializeComponent();
            PatientViewModel _patientViewModel = new PatientViewModel();
            this.DataContext = _patientViewModel;
        }
    }
}
