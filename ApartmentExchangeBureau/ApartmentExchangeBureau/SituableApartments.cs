using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ApartmentExchangeBureau
{
    public partial class SituableApartments : Form
    {
        List<Flat> flat = new List<Flat>();// список подходящих квартир
        Flat flat1;
        Flat flat2;

        public SituableApartments(List<Flat> flat)
        {
            InitializeComponent();
            this.flat = flat;
            MainForm main = Owner as MainForm;
        }

        private void SituableApartments_Load(object sender, EventArgs e)
        {
            MainForm main = Owner as MainForm;
            foreach (var item in flat)
            {
                dataGridView1.Rows.Add(item.Rooms, item.Floor, item.Area, item.Address);
            }       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = Owner as MainForm;
            Close();
            main.flag = true;
        }

        private void buttonApplication_Click(object sender, EventArgs e)
        {
            MainForm main = Owner as MainForm;
            int index = dataGridView1.CurrentRow.Index;
            int index1 = 0;
            Flat apart = new Flat();
            for (int i = 0; i < flat.Count; i++)
            {
                if (i == index)
                {
                    apart = flat.ElementAt(i);
                    flat1 = apart;
                }
            }
            dataGridView1.Rows.RemoveAt(index);
            foreach (var item in main.flats)
            {
                if (item.Rooms == apart.Rooms && item.Floor == apart.Floor && item.Area == apart.Area && item.Address == apart.Address)
                {
                    main.flats.Remove(item);
                    break;
                }
                index1++;
            }
            flat2.Address = main.flat2Address;
            flat2.Rooms = int.Parse(main.flat2Room);
            flat2.Floor = int.Parse(main.flat2Floor);
            flat2.Area = Convert.ToDouble(main.flat2Area);
            main.index = index1;
            MessageBox.Show("Заявка принята и сформирована в PDF-файл!");
            PDF();
            Close();
        }

        private void PDF()
        {
            var document = new Document(PageSize.A4, 20, 20, 30, 20);

            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALNBI.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);


            using (var writer = PdfWriter.GetInstance(document, new FileStream("Заявка.pdf", FileMode.Create)))
            {
                document.Open();
                document.NewPage();

                document.Add(new Paragraph("\t\t\tБюро обмена квартир \"Винзили\"\n", font));
                document.Add(new Paragraph("\t\t\t\t\t\t \nРиелтор: Топычканов Иван\n", font));
                document.Add(new Paragraph("\n\nЗаявка на обмен квартир", font));
                document.Add(new Paragraph($"1.\nАдрес:{flat1.Address}\nКоличество комнат:{flat1.Rooms}\nЭтаж:{flat1.Floor}\nПлощадь:{flat1.Area}", font));
                document.Add(new Paragraph($"\n2.\nАдрес:{flat2.Address}\nКоличество комнат:{flat2.Rooms}\nЭтаж:{flat2.Floor}\nПлощадь:{flat2.Area}", font));

                document.Close();
                writer.Close();
            }
        }
    }
}
