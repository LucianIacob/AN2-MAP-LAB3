using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_3_MAP
{
    public class Console
    {
        private Dictionar<int, Student> myDictionar = new Dictionar<int, Student>();

        public void run()
        {
            myDictionar.add(11474, new Student(11474, "Guranda Bogdan", 9.5));
            myDictionar.add(11574, new Student(11574, "Tiperciuc Corvin", 9.3));
            myDictionar.add(11434, new Student(11434, "Galea Ronaldo", 7.2));
            myDictionar.add(17474, new Student(17474, "Iacob Lucian", 7.8));
            myDictionar.add(14742, new Student(14742, "Trif George", 6.9));
            while (true)
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("---MENIU PRINCIPAL---");
                System.Console.WriteLine("1. Adaugă student.");
                System.Console.WriteLine("2. Caută student.");
                System.Console.WriteLine("3. Editează student.");
                System.Console.WriteLine("4. Elimină student.");
                System.Console.WriteLine("5. Afişează studenţii.");
                System.Console.WriteLine("0. Ieşire.");
                System.Console.Write("---Daţi opţiunea: ");

                string x = System.Console.ReadLine();
                try
                {
                    int cmd = Convert.ToInt32(x);

                    if (cmd == 0) break;
                    else if (cmd == 1)
                    {
                        int nrmatricol = 0;
                        double media = 0;
                        System.Console.Write("Dati numarul matricol: ");
                        try
                        {
                            string nrm = System.Console.ReadLine();
                            nrmatricol = Convert.ToInt32(nrm);
                            if (myDictionar.find(nrmatricol) != null)
                                System.Console.WriteLine(" @ Studentul exista deja!");
                            else
                            {
                                System.Console.Write("Dati numele studentului: ");
                                string nume = System.Console.ReadLine();

                                System.Console.Write("Dati media: ");
                                media = Convert.ToDouble(System.Console.ReadLine());

                                Student s = new Student(nrmatricol, nume, media);
                                System.Console.WriteLine(myDictionar.add(nrmatricol, s));
                            }
                        }
                        catch (Exception)
                        {
                            System.Console.WriteLine(" @ Invalid input");
                        }
                    }

                    else if (cmd == 2)
                    {
                        int nrmatricol = 0;
                        System.Console.Write("Dati numarul matricol: ");
                        try
                        {
                            nrmatricol = Convert.ToInt32(System.Console.ReadLine());
                            Student o = myDictionar.find(nrmatricol);
                            if (o != default(Student)) System.Console.WriteLine(" @ " + ((Student)o).ToString());
                            else System.Console.WriteLine(" @ Studentul nu exista!");
                        }
                        catch (Exception)
                        {
                            System.Console.WriteLine(" @ Invalid input");
                        }
                    }

                    else if (cmd == 3)
                    {
                        int nrmatricol = 0;
                        System.Console.Write("Dati numarul matricol al studentului: ");
                        try
                        {
                            nrmatricol = Convert.ToInt32(System.Console.ReadLine());
                            Student o = myDictionar.find(nrmatricol);
                            if (o == default(Student)) System.Console.WriteLine(" @ Studentul nu exista");
                            else
                            {
                                String nume = ((Student)o).getNume();
                                System.Console.Write("Dati noua medie pentru acest student: ");
                                double media = Convert.ToDouble(System.Console.ReadLine());
                                System.Console.WriteLine(" @ " + myDictionar.update(nrmatricol, new Student(nrmatricol, nume, media)));
                            }
                        }
                        catch (Exception)
                        {
                            System.Console.WriteLine(" @ Invalid input");
                        }
                    }

                    else if (cmd == 4)
                    {
                        int nrmatricol = 0;
                        System.Console.Write("Dati numarul matricol al studentului: ");
                        try
                        {
                            nrmatricol = Convert.ToInt32(System.Console.ReadLine());
                            Student o = myDictionar.find(nrmatricol);
                            if (o != default(Student)) System.Console.WriteLine(" @ " + myDictionar.remove(nrmatricol));
                            else System.Console.WriteLine(" @ Ati introdus un numar matricol neexistent!");
                        }
                        catch (Exception)
                        {
                            System.Console.WriteLine(" @ Invalid input");
                        }
                    }
                    else if (cmd == 5)
                    {
                        System.Console.WriteLine("@ ");
                        for (Dictionar<int, Student>.Iterator i = myDictionar.getIterator(); i.valid(); i.next())
                            System.Console.WriteLine((i.element()).valoare.ToString());
                        System.Console.WriteLine("@ ");
                    }
                }
                catch (Exception) { System.Console.WriteLine(" @ Invalid command!"); }
            }
        }
    }
}