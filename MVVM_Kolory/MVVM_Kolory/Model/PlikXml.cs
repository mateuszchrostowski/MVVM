using System.Globalization;
using System.Xml.Linq;

namespace MVVM_Kolory.Model
{
    public static class PlikXml
    {
        private static string ścieżkaPliku =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "kolor.xml");

        private static IFormatProvider fp = new CultureInfo("pl-PL");

        //LINQ to XML
        public static void Zapisz(double r, double g, double b)
        {
            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment($"Utworzono {DateTime.Now}"),
                new XElement("ustawienia",
                    new XElement("R", r.ToString(fp)),
                    new XElement("G", g.ToString(fp)),
                    new XElement("B", b.ToString(fp))
                )
            );
            xml.Save(ścieżkaPliku);
        }

        public static void Zapisz(Kolor kolor)
        {
            Zapisz(kolor.R, kolor.G, kolor.B);
        }

        //public static (double R, double G, double B) Czytaj()
        public static Kolor Czytaj()
        {
            try
            {
                XDocument xml = XDocument.Load(ścieżkaPliku);
                string sr = xml.Root.Element("R").Value;
                double dr = double.Parse(sr, fp);
                string sg = xml.Root.Element("G").Value;
                double dg = double.Parse(sg, fp);
                string sb = xml.Root.Element("B").Value;
                double db = double.Parse(sb, fp);
                //return (dr, dg, db);
                //return new Kolor { R = dr, G = dg, B = db };
                return new Kolor(dr, dg, db);
            }
            catch
            {
                //return (0.0, 0.0, 0.0);
                return Kolor.Czerń;
            }
        }
    }
}
