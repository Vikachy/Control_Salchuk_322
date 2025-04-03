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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Control_Salchuk_322
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int dbScore = int.Parse(txtDatabase.Text);
                int devScore = int.Parse(txtDevelopment.Text);
                int maintScore = int.Parse(txtMaintenance.Text);

                if (dbScore > 22 || devScore > 38 || maintScore > 20)
                {
                    MessageBox.Show("Баллы не могут превышать максимальные значения для модулей!",
                                  "Ошибка",
                                  MessageBoxButton.OK,
                                  MessageBoxImage.Error);
                    return;
                }

                string result = GradeCalculator.CalculateGrade(dbScore, devScore, maintScore);
                txtResult.Text = $"Общая сумма баллов: {dbScore + devScore + maintScore}\nОценка: {result}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите целые числа для баллов!",
                              "Ошибка",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }
    }

    public static class GradeCalculator
    {
        public static string CalculateGrade(int dbScore, int devScore, int maintScore)
        {
            // 1. Проверка отрицательных значений
            if (dbScore < 0 || devScore < 0 || maintScore < 0)
                return "Некорректная сумма баллов";

            // 2. Проверка превышения максимальных значений по модулям
            if (dbScore > 22 || devScore > 38 || maintScore > 20)
                return "Некорректная сумма баллов";

            int total = dbScore + devScore + maintScore;

            // 3. Проверка общей суммы
            if (total > 80)
                return "Некорректная сумма баллов";

            if (total >= 56)
                return "5 (отлично)";
            if (total >= 32)
                return "4 (хорошо)";
            if (total >= 16)
                return "3 (удовлетворительно)";

            return "2 (неудовлетворительно)";
        }
    }
}
