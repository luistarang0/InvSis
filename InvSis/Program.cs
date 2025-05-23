using InvSis.Views;


namespace InvSis
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Se crea una �nica instancia del formulario de login
            frmLogIn login_form = new frmLogIn();
            if (login_form.ShowDialog() == DialogResult.OK)
            {
                // Si el login es exitoso, se abre la ventana principal
                Application.Run(new frmMDI());
            }
        }
    }
}
