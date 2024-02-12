using Nupi_Clinic.Data;
using Nupi_Clinic.Model;
using Nupi_Clinic.Repositories;
using Nupi_Clinic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nupi_Clinic.View
{
    /// <summary>
    /// Interaction logic for AddPatientView.xaml
    /// </summary>
    public partial class AddPatientView : UserControl
    {
        private readonly PatientViewModel _patientViewModel;
        public AddPatientView(PatientViewModel patientViewModel)
        {
            InitializeComponent();
            // Assign the provided PatientViewModel to the local variable
            _patientViewModel = patientViewModel;
            // Set the DataContext of the view to the PatientViewModel
            DataContext = _patientViewModel;
        }
    }
}
