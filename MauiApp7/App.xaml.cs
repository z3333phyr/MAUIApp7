using MauiApp7.Models;
using Microsoft.Maui.Controls;
using System.IO;

namespace MauiApp7
{
    public partial class App : Application

    {
        public static StudentRepository StudentRepo { get; private set; }
        public App(StudentRepository repo)
        {
            InitializeComponent();

            StudentRepo = repo;

            MainPage = new AppShell();
            
            

    }
}
}
