using MauiApp7.Models;

namespace MauiApp7
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNewButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            App.StudentRepo.AddNewStudent(newStudent.Text);
            statusMessage.Text = App.StudentRepo.StatusMessage;
        }

        private void OnGetButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            List<Student> section = App.StudentRepo.GetSection();
            sectionList.ItemsSource = section;
        }

    }

}
