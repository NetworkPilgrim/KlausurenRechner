namespace KlausurenRechner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Den Anwender um die Eingabe der Maximal zu erreichenden Punktzahl bitten
            int max_points = GetIntegerInput("Maximale Punktezahl: ");
            // Den Anwender um die Eingabe der erreichten Punktzahl bitten
            int points = GetIntegerInput("Erreichte Punktzahl: ", max_points);

            // Note errechnen und Ausgeben lassen
            GenerateGrade(max_points, points);

            // Ausgabe des Textes zur Notentabelle
            Console.WriteLine("\nNotentabelle: ");
            // For schleife für alle Punktzahlen von 60 bis 0
            for (int i = 60; i >= 0; i--)
            {
                // Berechnen und Ausgabe der Note
                GenerateGrade(max_points, i);
            }
        }

        /// <summary>
        /// Methode zur errechnung der Note und der Ausgabe des Ergebnisses.
        /// </summary>
        /// <param name="max_points"> Maximal zu erreichenende Punktzahl</param>
        /// <param name="points"> Tatschächlich erreichte Punktzahl</param>
        private static void GenerateGrade(int max_points, int points)
        {
            // Ueberprüfung ob die Punktzahl kleiner oder gleich 20 ist
            if (points <= 20)
            {
                // Ausgabe der Note Fuenf und der Punkte
                Console.WriteLine(points + " von " + max_points + " entspricht der Note 5.");
                // Return um die Methode nicht weiter aus zu fuehren
                return;
            }
            // Berechnen der Note als Dezimalwert
            double mark_num = (double)(((max_points - points) * 0.1) + 1);
            // Nachkommastellen entfernen um die "volle" Note zu erhalten
            int mark = (int)(Math.Truncate(mark_num));
            // Nachkommawert ermitteln
            double deci = mark_num - mark;
            // Suffix Variable erstellen und auf leer setzen
            string suffix = "";

            // Vergleichen ist der Nachkommawert kleiner oder gleich 0,3
            if (deci >= 0.6)
            {
                // Suffix auf "+" setzen
                suffix = "+";
                mark++;
            }
            // Vergleichen ist der Nachkommawert groesser oder gleich 0,6
            else if (deci >= 0.3)
            {
                // Suffix auf "-" setzen
                suffix = "-";
            }
            // Ausgabe der Note und der Punktzahl
            Console.WriteLine(points + " von " + max_points + " entspricht der Note " + mark + suffix);
        }

        /// <summary>
        /// Den Anwender die Eingabe von Daten ermöglichen
        /// </summary>
        /// <param name="text">Eine Nachricht die den Anwender auf die Eingabe hinweisen soll.</param>
        /// <returns>Eine Ganzzahl</returns>
        private static int GetIntegerInput(string? text, int? number = null)
        {
            // Ueberpruefen ob ein text angezeigt werden soll
            if (text != null) Console.Write(text);
            // Den Anwender auffordern Daten einzugeben
            // Daten werden in der variable input gespeichert
            string? input = Console.ReadLine();

            // Erstellen einer variable zu speicherung als korrekten Datentyp
            int value;

            // Try schleife zur ermittelung der Korrekten Dateneingabe
            try
            {
                // Konvertieren der Eingabe in einene Ganzzahl
                value = Convert.ToInt32(input);
            }
            // Abgreifen eines Formatierung Fehlers
            catch (Exception)
            {
                // Ausgabe für den Anwender, 
                Console.WriteLine("Das Programm erlaubt nur die Eingabe von Ganzen Zahlen bisn zu einem Maximalwert von 2.147.483.647!");
                // Rekuriver Aufrufen der Methode, die Eingabe erneut Tätigen
                value = GetIntegerInput(text, number);
            }

            if (number != null && value > number)
            {
                Console.WriteLine("Die Zahl muss kleiner als " + number + " sein.");
                value = GetIntegerInput(text, number);
            }
            // Den Wert zurückliefern
            return value;
        }
    }
}