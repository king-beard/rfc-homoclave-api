namespace RfcHomoclave.Middleware.Helpers.RfcHomoclave
{
    public static class Anexo
    {
        // ANEXO 1.- TABLA PARA ASIGNAR VALORES A LOS CARACTERES QUE APARECEN EN EL NOMBRE AL QUE SE LE CALCULARA LA CLAVE DIFERENCIADORA DE HOMONIMO
        public static string AnexoOne(this char key)
        {
            Dictionary<char, string> dictionaryAnexoOne = new()
            {
                {' ', "00"}, {'0', "00"}, {'1', "01"}, {'2', "02"}, {'3', "03"},
                {'4', "04"}, {'5', "05"}, {'6', "06"}, {'7', "07"}, {'8', "08"},
                {'9', "09"}, {'&', "10"}, {'A', "11"}, {'B', "12"}, {'C', "13"},
                {'D', "14"}, {'E', "15"}, {'F', "16"}, {'G', "17"}, {'H', "18"},
                {'I', "19"}, {'J', "21"}, {'K', "22"}, {'L', "23"}, {'M', "24"},
                {'N', "25"}, {'O', "26"}, {'P', "27"}, {'Q', "28"}, {'R', "29"},
                {'S', "32"}, {'T', "33"}, {'U', "34"}, {'V', "35"}, {'W', "36"},
                {'X', "37"}, {'Y', "38"}, {'Z', "39"}, {'Ñ', "40"}
            };

            return dictionaryAnexoOne.ContainsKey(key) ? dictionaryAnexoOne[key] : "00";
        }

        // ANEXO 2.- TABLA DE VALORES QUE SE ASIGNAN A LA CLAVE DIFERENCIADORA DE HOMONIMIO EN BASE AL COEFICIENTE Y AL RESIDUO
        public static string AnexoTwo(this string key)
        {
            Dictionary<string, string> dictionaryAnexoTwo = new()
            {
                {"0", "1"}, {"1", "2"}, {"2", "3"}, {"3", "4"}, {"4", "5"},
                {"5", "6"}, {"6", "7"}, {"7", "8"}, {"8", "9"}, {"9", "A"},
                {"10", "B"}, {"11", "C"}, {"12", "D"}, {"13", "E"}, {"14", "F"},
                {"15", "G"}, {"16", "H"}, {"17", "I"}, {"18", "J"}, {"19", "K"},
                {"20", "L"}, {"21", "M"}, {"22", "N"}, {"23", "P"}, {"24", "Q"},
                {"25", "R"}, {"26", "S"}, {"27", "T"}, {"28", "U"}, {"29", "V"},
                {"30", "W"}, {"31", "X"}, {"32", "Y"}, {"33", "Z"}
            };

            return dictionaryAnexoTwo[key];
        }

        // ANEXO 3.- TABLA DE VALORES PARA LO GENERACIÓN DEL CÓDIGO VERIFICADOR DEL REGISTRO FEDERAL DE CONTRIBUYENTES.
        public static string AnexoThree(this char key)
        {
            Dictionary<char, string> dictionaryAnexoThree = new()
            {
                {'0', "00"}, {'1', "01"}, {'2', "02"}, {'3', "03"}, {'4', "04"},
                {'5', "05"}, {'6', "06"}, {'7', "07"}, {'8', "08"}, {'9', "09"},
                {'A', "10"}, {'B', "11"}, {'C', "12"}, {'D', "13"}, {'E', "14"},
                {'F', "15"}, {'G', "16"}, {'H', "17"}, {'I', "18"}, {'J', "19"},
                {'K', "20"}, {'L', "21"}, {'M', "22"}, {'N', "23"}, {'&', "24"},
                {'O', "25"}, {'P', "26"}, {'Q', "27"}, {'R', "28"}, {'S', "29"},
                {'T', "30"}, {'U', "31"}, {'V', "32"}, {'W', "33"}, {'X', "34"},
                {'Y', "35"}, {'Z', "36"}, {' ', "37"}, {'Ñ', "38"}
            };

            return dictionaryAnexoThree[key];
        }
    }
}
