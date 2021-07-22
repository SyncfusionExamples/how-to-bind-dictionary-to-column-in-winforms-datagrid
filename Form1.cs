using Syncfusion.WinForms.DataGrid;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SfDataGridDemo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            sfDataGrid.AutoGenerateColumns = false;
            sfDataGrid.DataSource = new ViewModel().StudentDetails; 

            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "StudentID", HeaderText = "Student ID" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "StudentName", HeaderText = "Student Name" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Major", HeaderText = "Major" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Marks[Subject1]", HeaderText = "Marks[Subject1]" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Marks[Subject2]", HeaderText = "Marks[Subject2]" });            
        }       
    }

    public class Model : INotifyPropertyChanged
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        private Dictionary<string, int> _marks;
        public Dictionary<string, int> Marks
        {
            get
            {
                return _marks;
            }
            set
            {
                _marks = value;
                OnPropertyChanged("Marks");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class ViewModel
    {
        public ObservableCollection<Model> studentDetails;

        public ViewModel()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("Subject1", 85);
            dictionary.Add("Subject2", 96);


            var dict1 = new Dictionary<string, int>();
            dict1.Add("Subject1", 100);
            dict1.Add("Subject2", 70);

            studentDetails = new ObservableCollection<Model>();

            studentDetails.Add(new Model()
            {
                StudentID = 101,
                StudentName = "Joseph",
                Age = 25,
                Major = "Psychology",
                Marks = dictionary,

            });

            studentDetails.Add(new Model()
            {
                StudentID = 102,
                StudentName = "Martin",
                Age = 32,
                Major = "French",
                Marks = dict1,

            });

            studentDetails.Add(new Model()
            {
                StudentID = 103,
                StudentName = "Christina Berglund",
                Age = 45,
                Major = "Electornics",
                Marks = dictionary,

            });

            studentDetails.Add(new Model()
            {
                StudentID = 104,
                StudentName = "Steve Markin",
                Age = 26,
                Major = "Journalism",
                Marks = dict1,

            });

            studentDetails.Add(new Model()
            {
                StudentID = 105,
                StudentName = "Maria Anders",
                Age = 29,
                Major = "Astronomy",
                Marks = dictionary,

            });

            studentDetails.Add(new Model()
            {
                StudentID = 106,
                StudentName = "Jacobs",
                Age = 38,
                Major = "Science",
                Marks = dict1,
            });
        }

        public ObservableCollection<Model> StudentDetails
        {
            get { return studentDetails; }
            set { value = studentDetails; }
        }
    }
}
