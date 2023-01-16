using Hamburguesa_EduardoHidalgo.Data;

namespace Hamburguesa_EduardoHidalgo;

public partial class App : Application
{

    public static BurgerDatabase BurgerRepo { get; private set; }

    public App(BurgerDatabase repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		BurgerRepo = repo;
	}

}
