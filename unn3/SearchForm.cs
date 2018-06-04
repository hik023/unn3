using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unn3
{
    public partial class SearchForm : Form
    {
        List<Car> list_searched = new List<Car>();
        DataTable autoTable = new DataTable();
        DataColumn colNumber = new DataColumn("№");
        DataColumn colCarType = new DataColumn("Тип машины");
        DataColumn colCarModel = new DataColumn("Модель");
        DataColumn colAge = new DataColumn("Год выпуска");
        DataColumn colPriceNew = new DataColumn("Стоимость новой");
        DataColumn colPriceCalculated = new DataColumn("Рассчитанная стоимость");
        List<Car> working = new List<Car>();
        public SearchForm()
        {
            InitializeComponent();
            autoTable.Columns.Add(colNumber);
            autoTable.Columns.Add(colCarType);
            autoTable.Columns.Add(colCarModel);
            autoTable.Columns.Add(colAge);
            autoTable.Columns.Add(colPriceNew);
            autoTable.Columns.Add(colPriceCalculated);


            dgSearch.DataSource = autoTable;
        }

        public void Get_list(List<Car> list)
        {
            foreach (Car el in list)
            {
                switch (el.type)
                {
                    case "Легковая":
                        Console.WriteLine(el.GetType());
                        LightCar item1 = el as LightCar;
                        DataRow row1 = autoTable.NewRow();
                        row1[colNumber] = item1.number;
                        row1[colCarType] = item1.type;
                        row1[colCarModel] = item1.model;
                        row1[colAge] = item1.age;
                        row1[colPriceNew] = item1.price;
                        row1[colPriceCalculated] = item1.price_calculation();

                        autoTable.Rows.Add(row1);
                        break;
                    case "Грузовая":
                        HugeCar item2 = el as HugeCar;
                        DataRow row2 = autoTable.NewRow();
                        row2[colNumber] = item2.number;
                        row2[colCarType] = item2.type;
                        row2[colCarModel] = item2.model;
                        row2[colAge] = item2.age;
                        row2[colPriceNew] = item2.price;
                        row2[colPriceCalculated] = item2.price_calculation();

                        autoTable.Rows.Add(row2);
                        break;
                }
            }
        }
    }
}
