namespace Lab2_3_MAP
{
    public class Student
    {
        private int matricol;
        private string nume;
        private double medie;

        Student()
        {
            matricol = 1;
            nume = "";
            medie = 0;
        }

        public Student(int matricol, string nume, double medie)
        {
            this.matricol = matricol;
            this.nume = nume;
            this.medie = medie;
        }

        public void setMatricol(int matricol)
        {
            this.matricol = matricol;
        }
        public void setNume(string nume)
        {
            this.nume = nume;
        }
        public void setMedie(double medie)
        {
            this.medie = medie;
        }

        public int getMatricol()
        {
            return matricol;
        }
        public double getMedie()
        {
            return medie;
        }
        public string getNume()
        {
            return nume;
        }

        public override string ToString()
        {
            return matricol + " " + nume + " " + medie;
        }
    }
}