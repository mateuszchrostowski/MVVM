namespace AsystentZakupowy.Model
{
    public class Sumator
    {
        private decimal suma = 0;
        private decimal limit;

        public Sumator(decimal suma = 0, decimal limit = 200)
        {
            this.suma = suma;
            this.limit = limit;
        }

        public decimal Suma { get => suma; }

        public bool CzyMożnaDodać(decimal kwota)
        {
            return kwota > 0 && suma + kwota <= limit;
        }

        public void Dodaj(decimal kwota)
        {
            if (!CzyMożnaDodać(kwota)) throw new Exception("Kwota nie może być dodana");
            suma += kwota;
        }
    }
}
