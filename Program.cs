using FirebaseSharp.Portable;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace SMART_BIN
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
            //QRCode qrCode = new QRCode(qrCodeData);
            //Bitmap qrCodeImage = qrCode.GetGraphic(20);
            //qrCodeImage.Save("qrcode.bmp");

            //new Program().Run().Wait();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //private async Task Run()
        //{
        //    FirebaseApp app = new FirebaseApp(new Uri("https://smartbin-95f7a.firebaseio.com/"), "rOu2qW7xwYDz9jD7RCAHqnpFfyYdVTuTHQcJ0TXL");
        //    var scoresRef = app.Child("user");
        //    scoresRef.OrderByValue()
        // .LimitToLast(3)
        // .On("value", (snapshot, child, context) =>
        // {
        //     foreach (var data in snapshot.Children)
        //     {
        //         Console.WriteLine("The {0} dinosaur\'s score is {1}",
        //                             data.Key, data.Value<int>());
        //     }
        // });
        //}
    }
}