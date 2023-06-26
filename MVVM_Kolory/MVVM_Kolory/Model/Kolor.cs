namespace MVVM_Kolory.Model
{
    public class Kolor
    {
        private double r, g, b; //zakres od 0 do 1

        private double ograniczZakres(double wartość)
        {
            if (wartość < 0.0) return 0.0;
            if (wartość > 1.0) return 1.0;
            return wartość;
        }


        public double R
        {
            get => ograniczZakres(r);
            set => r = value;
        }

        public double G { get => ograniczZakres(g); set => g = value; }
        public double B { get => ograniczZakres(b); set => b = value; }

        public Kolor(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static readonly Kolor Czerń = new Kolor(0, 0, 0);
    }
}
