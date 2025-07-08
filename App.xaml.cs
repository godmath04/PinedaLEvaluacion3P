using PinedaLEvaluacion3P.Services;
namespace PinedaLEvaluacion3P
{
    public partial class App : Application
    {

        //Iniciacion de singleton
        private static ProyectoService _database;

        public static ProyectoService Database
        {
            get
            {
                //Si el _database es null crea una nueva instancia
                if (_database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "proyectos.db3");
                    _database = new ProyectoService(dbPath);

                }
                return _database;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
