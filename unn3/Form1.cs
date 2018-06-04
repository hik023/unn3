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
    public partial class Form1 : Form
    {

        List<Car> listOfCars = new List<Car>();
        DataTable autoTable = new DataTable();
        int number = 1;
        int index_to_copy;
        DataColumn colNumber = new DataColumn("№");
        DataColumn colCarType = new DataColumn("Тип машины");
        DataColumn colCarModel = new DataColumn("Модель");
        DataColumn colAge = new DataColumn("Год выпуска");
        DataColumn colPriceNew = new DataColumn("Стоимость новой");
        DataColumn colPriceCalculated = new DataColumn("Рассчитанная стоимость");


        public Form1()
        {
            InitializeComponent();
            autoTable.Columns.Add(colNumber);
            autoTable.Columns.Add(colCarType);
            autoTable.Columns.Add(colCarModel);
            autoTable.Columns.Add(colAge);
            autoTable.Columns.Add(colPriceNew);
            autoTable.Columns.Add(colPriceCalculated);


            dgView.DataSource = autoTable;
        }


        private void DrawTable()
        {
            foreach (Car el in listOfCars)
            {
                switch (el.type)
                {
                    case "Легковая":
                        Console.WriteLine(el.GetType());
                        LightCar item1 = el as LightCar;
                        DataRow row1 = autoTable.NewRow();
                        row1[colNumber] = item1.number;
                        row1[colCarModel] = item1.model;
                        row1[colCarType] = item1.type;
                        row1[colAge] = item1.age;
                        row1[colPriceNew] = item1.price;
                        row1[colPriceCalculated] = item1.price_calculation();

                        autoTable.Rows.Add(row1);

                        break;
                    case "Грузовая":
                        HugeCar item2 = el as HugeCar;
                        DataRow row2 = autoTable.NewRow();
                        row2[colNumber] = item2.number;
                        row2[colCarModel] = item2.model;
                        row2[colCarType] = item2.type;
                        row2[colAge] = item2.age;
                        row2[colPriceNew] = item2.price;
                        row2[colPriceCalculated] = item2.price_calculation();

                        autoTable.Rows.Add(row2);
                        break;
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            autoTable.Rows.Clear();
            try
            {
                switch (cbType.Text)
                {
                    case "Легковой":

                        LightCar item1 = new LightCar(
                            tbModel.Text, tbAge.Text, tbPrice.Text);
                        item1.number = number;
                        number += 1;
                        listOfCars.Add(item1);

                        break;

                    case "Грузовой":

                        HugeCar item2 = new HugeCar(
                            tbModel.Text, tbAge.Text, tbPrice.Text);
                        item2.number = number;
                        number += 1;
                        listOfCars.Add(item2);

                        break;
                    default:
                        MessageBox.Show("Выберите тип машины!");
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Введены не корректные данные \nили не все поля заполнены!");
            }

            DrawTable();

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            autoTable.Rows.Clear();
            switch (cbSortType.Text)
            {
                case "По цене (возрастание)":
                    listOfCars.Sort(new SortUpPrice());
                    break;
                case "По выпуску (убывание)":
                    listOfCars.Sort(new SortDownAge());
                    break;
                case "По цене (убывание)":
                    listOfCars.Sort(new SortDownPrice());
                    break;
                case "По выпуску (возрастание)":
                    listOfCars.Sort(new SortUpAge());
                    break;
                default:
                    break;
            }
            DrawTable();
        }

        private void cbSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSort.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            autoTable.Rows.Clear();
            try
            {
                foreach (Car el in listOfCars)
                {
                    if (el.number == Convert.ToInt32(tbDelete.Text))
                    {
                        listOfCars.Remove(el);
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Введены не корректные данные \nили не все поля заполнены!");
            }
            DrawTable();
        }

        private void dgView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            btnCopy.Enabled = true;
            index_to_copy = e.RowIndex;

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            autoTable.Rows.Clear();
            foreach (Car el in listOfCars)
            {
                if (el.number == index_to_copy + 1)
                {
                    if (el.type == "Легковая")
                    {
                        LightCar copied_car = new LightCar(el.model, el.age, el.price);
                        copied_car.number = number;
                        number += 1;
                        listOfCars.Add(copied_car);
                    }
                    else
                    {
                        HugeCar copied_car = new HugeCar(el.model, el.age, el.price);
                        copied_car.number = number;
                        number += 1;
                        listOfCars.Add(copied_car);
                    }

                    break;
                }
            }
            DrawTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            List<Car> searched = new List<Car>();
            foreach (Car car in listOfCars)
            {
                if (car.model == tbSearchModel.Text && car.age == tbSearchAge.Text)
                {
                    searched.Add(car);
                }
            }
            searchForm.Get_list(searched);
            searchForm.Show();
        }
    }
}
