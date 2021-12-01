using Efectivo.Models;
using GoldenToolKit;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Efectivo.ViewModels
{
    public class TicketMachinePageViewModel : ModelBase
    {
        QrGenerator generator;
        private ClientModel client;
        private ImageSource imagen;
        public ImageSource Imagen{
            get => imagen;
            set
            {
                imagen = value;
                OnPropertyChanged();
            }
        }
        private string labelVi;
        public string LabelVi
        {
            get => labelVi;
            set
            {
                labelVi = value;
                OnPropertyChanged();
            }
        }
        public ICommand GenerateCommand { get; set; }
        public TicketMachinePageViewModel()
        {
            client = new ClientModel();
            generator = new QrGenerator();
            GenerateCommand = new Command(GenerateQR);
            LabelVi = IVisibilityEnum.GetString(VisibilityLevel.Hidden);
        }
        public void GenerateQR(object obj)
        {
            Guid id = Guid.NewGuid();
            Bitmap qr = generator.Generator(id.ToString());
            client = new ClientModel()
            {
                ID = id,
                Hora = DateTime.Now,
            };
            var pgSize = new iTextSharp.text.Rectangle(90, 110);
            Document doc = new Document(pgSize, 1f, 1f, 1f, 1f);
            PdfWriter.GetInstance(doc, new FileStream(Environment.CurrentDirectory + $"/ {id}.pdf", FileMode.Create));
            doc.Open();
            var item = new Paragraph("Hora de entrada:" + client.Hora);
            item.Font.Size = 4;
            item.IndentationLeft = 5;
            doc.Add(item);
            iTextSharp.text.Image Qr = iTextSharp.text.Image.GetInstance(qr, System.Drawing.Imaging.ImageFormat.Bmp);
            Qr.ScaleAbsoluteWidth(100);
            Qr.ScaleAbsoluteHeight(90);
            Qr.Alignment = -5;
            doc.Add(Qr);
            doc.Close();
            SQLConnect connect = new SQLConnect();
            connect.ConnectionDB("Proyectos", ".");
            connect.ExecCommandSP(connect.Connection, "SP_REGISTERTICKET",
                new SqlParameter("@ID", client.ID),
                new SqlParameter("@HOUR", client.Hora));
            LabelVi = IVisibilityEnum.GetString(VisibilityLevel.Visible);
            Imagen = Imaging.CreateBitmapSourceFromHBitmap(qr.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        }
        
    }
}
