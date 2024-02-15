using Nupi_Clinic.Model;
using Nupi_Clinic.Repositories;
using Nupi_Clinic.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nupi_Clinic.View
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : UserControl
    {
        //private readonly PatientViewModel _patientViewModel;
        public PatientView()
        {
            InitializeComponent();
            PatientViewModel _patientViewModel = new PatientViewModel();
            DataContext = _patientViewModel;
        }
    }
}
