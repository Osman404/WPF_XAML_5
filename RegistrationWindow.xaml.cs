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

namespace CreateAuthorize
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        DBContainer db = new DBContainer();
        public RegistrationWindow()
        {
            InitializeComponent();
          
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
           if (login.Text == "" || password.Password == "" || lastName.Text == "" ||firstName.Text ==""||middleName.Text == "")
           {
                MessageBox.Show("Путсые поля");
                return;
           }
           if (db.UserSet.Select(item => item.Login).Contains(login.Text))
           {
                MessageBox.Show("Такой логин существует в системе");
                return;
           }
           User newUser = new User(){
               Login = login.Text,
               Password = password.Password,
               LastName = lastName.Text,
               FirstName = firstName.Text,
               MiddleName = middleName.Text
           };
            db.UserSet.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрировались");
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();

        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
			Close();
        }
    }
}
