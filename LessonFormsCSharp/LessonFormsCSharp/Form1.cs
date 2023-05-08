using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LessonFormsCSharp
{
    public partial class Form1 : Form
    {
        Country Russian = new Country("Россия", @"rus.jpg");
        Country USA = new Country("США", @"usa.jpg");
        Country Chine = new Country("Китай", @"chi.jpg");
        Country Englsh = new Country("Англия", @"eng.jpg");
        Country German = new Country("Германия", @"ger.jpg");

        List<Country> countries;
        Image icon;

        public Form1()
        {
            InitializeComponent();

            Russian.AddCity("Москва", "Петербург", "Екатеринбург", "Мурманск", "Омск");
            USA.AddCity("Нью-Йорк", "Вашингтон", "Бостон", "Флорида", "Чикаго");
            Chine.AddCity("Шанхай", "Гонконг", "Харбин", "Санья", "Пекин");
            Englsh.AddCity("Лондон", "Манчестер", "Ливерпуль", "Ноттингем", "Лестер");
            German.AddCity("Берлин", "Гамбург", "Мюнхен", "Кёльн", "Лейпциг");

            countries = new List<Country>() { Russian, USA, Chine, Englsh, German };

            comboBox1.Text = "Страны: ";
            foreach (var countr in countries)
            {
                comboBox1.Items.Add(countr.GetName());
            }

            listView1.SmallImageList = imageList1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) SetListView(countries[0]);
            else if (comboBox1.SelectedIndex == 1) SetListView(countries[1]);
            else if (comboBox1.SelectedIndex == 2) SetListView(countries[2]);
            else if (comboBox1.SelectedIndex == 3) SetListView(countries[3]);
            else if (comboBox1.SelectedIndex == 4) SetListView(countries[4]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) countries[0].AddCity(textBox1.Text);
            else if (comboBox1.SelectedIndex == 1) countries[1].AddCity(textBox1.Text);
            else if (comboBox1.SelectedIndex == 2) countries[2].AddCity(textBox1.Text);
            else if (comboBox1.SelectedIndex == 3) countries[3].AddCity(textBox1.Text);
            else if (comboBox1.SelectedIndex == 4) countries[4].AddCity(textBox1.Text);
        }

        // !!!!!!
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) countries[0].DeleteCity(countries[0].GetCity(listView1.SelectedIndices[0]));
            else if (comboBox1.SelectedIndex == 1) countries[1].DeleteCity(countries[1].GetCity(listView1.SelectedIndices[0]));
            else if (comboBox1.SelectedIndex == 2) countries[2].DeleteCity(countries[2].GetCity(listView1.SelectedIndices[0]));
            else if (comboBox1.SelectedIndex == 3) countries[3].DeleteCity(countries[3].GetCity(listView1.SelectedIndices[0]));
            else if (comboBox1.SelectedIndex == 4) countries[4].DeleteCity(countries[4].GetCity(listView1.SelectedIndices[0]));
        }

        private void SetListView(Country c)
        {
            listView1.Clear();
            icon = Image.FromFile(c.GetPatch());
            imageList1.Images.Clear();
            imageList1.Images.Add(icon);
            ListViewItem lvi = new ListViewItem();
            lvi.Text = c.GetName();
            lvi.ImageIndex = 0;
            listView1.Items.Add(lvi);

            for (int elem = 0; elem < c.countCities(); elem++)
            {
                listView1.Items.Add(c.GetCity(elem).GetNameCity());
            }
        }
    }
}

