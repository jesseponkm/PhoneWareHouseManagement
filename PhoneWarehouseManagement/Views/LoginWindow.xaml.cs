using System.IO;
using System.Text.Json;
using System.Windows;

namespace PhoneWarehouseManagement.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        string fileName = "appsettings.json";
        string email = null;
        string password = null;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string emailLogin = txtUser.Text;
            string passwordLogin = txtPass.Password;

            if (string.IsNullOrWhiteSpace(emailLogin))
            {
                MessageBox.Show("Email cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordLogin))
            {
                MessageBox.Show("Password cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (File.Exists(fileName))
            {
                try
                {
                    string jsonString = File.ReadAllText(fileName);
                    using (JsonDocument doc = JsonDocument.Parse(jsonString))
                    {
                        JsonElement root = doc.RootElement;
                        JsonElement adminElement = root.GetProperty("admin");

                        email = adminElement.GetProperty("email").GetString();
                        password = adminElement.GetProperty("password").GetString();
                    }

                    if (emailLogin.Equals(email) && passwordLogin.Equals(password))
                    {
                        this.Hide();
                        BrandManagement brandWindow = new BrandManagement();
                        brandWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.", "Authentication Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while reading the file: {ex.Message}", "File Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"The file '{fileName}' does not exist.", "File Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
