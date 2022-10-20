using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ApartmentExchangeBureau
{
    public partial class MainForm : Form
    {
        public List<Flat> flats = new List<Flat>();
        public int index = 0;
        public bool flag = false;
        public string flat2Address;
        public string flat2Room;
        public string flat2Floor;
        public string flat2Area;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string file = @"DataBaseFlats.txt";
            if (File.Exists(file))
            {
                StreamReader f = new StreamReader("DataBaseFlats.txt", Encoding.GetEncoding(1251));
                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    string[] data = s.Split('\t');
                    Flat flat = new Flat();
                    flat.Rooms = int.Parse(data[0]);
                    flat.Floor = int.Parse(data[1]);
                    flat.Area = Convert.ToDouble(data[2]);
                    flat.Address = data[3];
                    flats.Add(flat);
                    dataGridView1.Rows.Add(data);
                }
                f.Close();
            }  
        }

        private void buttonGetapplication_Click(object sender, EventArgs e)
        {
            flag = false;
            string countRoom = textBoxRooms.Text;
            string numberFloor = textBoxFloor.Text;
            string areaFlat = textBoxArea.Text;
            string addressFlat = textBoxAddress.Text;
            flat2Room = countRoom;
            flat2Floor = numberFloor;
            flat2Area = areaFlat;
            flat2Address = addressFlat;
            if (CheckCountRooms(countRoom) && CheckNumberFloor(numberFloor) && CheckArea(areaFlat))
            {
                List<Flat> flat = new List<Flat>();
                foreach (var item in flats)
                {
                    if (int.Parse(countRoom) == item.Rooms && int.Parse(numberFloor) == item.Floor && GetProcent(Convert.ToDouble(areaFlat), item.Area))
                    {
                        flat.Add(item);
                    }
                }
                if (flat.Count > 0)
                {
                    SituableApartments form = new SituableApartments(flat);
                    form.Owner = this;
                    form.ShowDialog();
                    if (!flag)
                    {
                        dataGridView1.Rows.RemoveAt(index);
                        RewriteTxt();
                    }
                    else
                    {
                        AddFlat(countRoom, numberFloor, areaFlat, addressFlat);
                        MessageBox.Show("Квартира не выбрана! Заявка добавлена в список.");
                    }
                }
                else
                {
                    AddFlat(countRoom, numberFloor, areaFlat, addressFlat);
                    MessageBox.Show("Подходящих квартир нет! Заявка добавлена в список.");
                }
                textBoxRooms.Clear();
                textBoxFloor.Clear();
                textBoxArea.Clear();
                textBoxAddress.Clear();
            }
            else
            {
                if (!CheckCountRooms(countRoom))
                {
                    MessageBox.Show("Количество комнат введено неверно!");
                }
                else if (!CheckNumberFloor(numberFloor))
                {
                    MessageBox.Show("Этаж введён неверно!");
                }
                else if (!CheckArea(areaFlat))
                {
                    MessageBox.Show("Площадь введена неверно");
                }
            }
        }

        private bool CheckCountRooms(string countRoom)
        {
            if (countRoom.Length < 1 || countRoom.Length > 2)
            {
                return false;
            }
            foreach (var item in countRoom)
            {
                if (!char.IsNumber(item))
                {
                    return false;
                }
            }
            if (int.Parse(countRoom) > 10)
            {
                return false;
            }
            return true;
        }

        private bool CheckNumberFloor(string numberFloor)
        {
            if (numberFloor.Length < 1 || numberFloor.Length > 2)
            {
                return false;
            }
            foreach (var item in numberFloor)
            {
                if (!char.IsNumber(item))
                {
                    return false;
                }
            }
            if (int.Parse(numberFloor) > 40)
            {
                return false;
            }
            return true;
        }

        private bool CheckArea(string areaFlat)
        {
            if (areaFlat.Length < 2 || areaFlat.Length > 6)
            {
                return false;
            }
            foreach (var item in areaFlat)
            {
                if (!char.IsNumber(item) && item != '.')
                {
                    return false;
                }
            }
            if (Convert.ToDouble(areaFlat) > 300)
            {
                return false;
            }
            return true;
        }

        private bool GetProcent(double flat1, double flat2)
        {
            if (flat1 == flat2)
            {
                return true;
            }
            else if (flat1 > flat2)
            {
                if (Convert.ToInt32((flat1 - flat2) / flat1 * 100) <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (Convert.ToInt32((flat2 - flat1) / flat2 * 100) <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private void RewriteTxt()
        {
            StreamWriter sw = new StreamWriter("DataBaseFlats.txt", false, Encoding.GetEncoding(1251));
            foreach (var item in flats)
            {
                sw.WriteLine(item.Rooms + "\t" + item.Floor + "\t" + item.Area + "\t" + item.Address);
            }
            sw.Close();
        }

        private void AddFlat(string countRoom, string numberFloor, string areaFlat, string addressFlat)
        {
            dataGridView1.Rows.Add(countRoom, numberFloor, areaFlat, addressFlat);
            Flat flat1 = new Flat();
            flat1.Rooms = int.Parse(countRoom);
            flat1.Floor = int.Parse(numberFloor);
            flat1.Area = Convert.ToDouble(areaFlat);
            flat1.Address = addressFlat;
            flats.Add(flat1);
            RewriteTxt();
        }
    }
}
