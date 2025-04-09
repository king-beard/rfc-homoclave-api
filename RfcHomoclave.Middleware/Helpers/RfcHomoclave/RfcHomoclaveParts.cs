using System.Text.RegularExpressions;

namespace RfcHomoclave.Middleware.Helpers.RfcHomoclave
{
    public static class RfcHomoclaveParts
    {
        public static string GenerateRfcWithOutHomoclave(string apellidoPaterno, string apellidoMaterno, string nombre, DateTime fechaNacimiento, string tipoPersona = "fisica")
        {
            string rfc = string.Empty;
            string newApellido = "";
            apellidoPaterno = apellidoPaterno.WordsNotUsed().Replace(" ", "");
            apellidoMaterno = apellidoMaterno.WordsNotUsed().Replace(" ", "");
            nombre = nombre.WordsNotUsed().RemoveCommonNames().Replace(" ", "");

            if (string.IsNullOrEmpty(apellidoPaterno))
                newApellido = apellidoMaterno;
            else if (string.IsNullOrEmpty(apellidoMaterno))
                newApellido = apellidoPaterno;

            if (tipoPersona == "fisica")
            {
                if (!string.IsNullOrEmpty(newApellido)) // Rule 7
                    rfc = $"{newApellido[0]}{newApellido[1]}{nombre[0]}{nombre[1]}";
                else if (apellidoPaterno.Length == 1 || apellidoPaterno.Length == 2) // Rule 4
                    rfc = $"{apellidoPaterno[0]}{apellidoMaterno[0]}{nombre[0]}{nombre[1]}";
                else
                    rfc = $"{apellidoPaterno[0]}{Regex.Match(apellidoPaterno[1..], "[AEIOU]").Value}{apellidoMaterno[0]}{nombre[0]}";
            }
            else if (tipoPersona == "moral")
            {
                var palabras = nombre.Split(' ');
                rfc = palabras[0][0].ToString() + palabras[1][0].ToString() + palabras[2][0].ToString();
            }

            rfc += fechaNacimiento.ToString("yyMMdd");

            return rfc;
        }

        // PROCEDIMIENTO PARA OBTENER LA CLAVE DIFERENCIADORA DE HOMONIMIA.
        public static string HomonimiaKey(string rfcSinHomoclave, string fullName)
        {
            // step 1.- Se asignaran valores a las letras del nombre o razón social de acuerdo a la tabla del Anexo 1.
            string convertAnexoOne = "0";
            char[] fullNameCharArray = fullName.ToCharArray();
            foreach (char c in fullNameCharArray)
                convertAnexoOne = $"{convertAnexoOne}{c.AnexoOne()}";

            int sum = 0;
            char[] convertAnexoOneCharArray = convertAnexoOne.ToCharArray();
            for (int i = 0; i < convertAnexoOneCharArray.Length - 1; i++)
            {
                //step 2.- Se ordenan los valores de la siguiente manera:
                char aux = convertAnexoOneCharArray[i + 1];
                int value1 = Convert.ToInt32($"{convertAnexoOneCharArray[i]}{aux}");
                int value2 = Convert.ToInt32($"{aux}");
                //step 3.- Se efectuaran las multiplicaciones de los números tomados de dos en dos para la posición de la pareja:
                int mult = value1 * value2;
                sum += mult;
            }

            //step 4.- Se suma el resultado de las multiplicaciones y del resultado obtenido, se tomaran las tres ultimas cifras y estas se dividen entre el factor 34
            int thirtyFourNumber = 34;
            int result = Convert.ToInt32(sum.ToString()[^3..]);
            //step 5.- Con el cociente y el residuo se consulta la tabla del Anexo II y se asigna la homonimia.
            int cociente = result / thirtyFourNumber;
            int residuo = result % thirtyFourNumber;

            string rfcHomonimia = $"{rfcSinHomoclave}{cociente.ToString().AnexoTwo()}{residuo.ToString().AnexoTwo()}";
            var (alphaPart, numericPart) = rfcHomonimia.SeparateText();
            rfcHomonimia = $"{alphaPart.DisadvantagesWords()}{numericPart}";

            return rfcHomonimia;
        }

        //PROCEDIMIENTO PARA CALCULAR EL DIGITO VERIFICADOR DEL REGISTRO FEDERAL DE CONTRIBUYENTES
        public static string DigitVerify(string rfcHomonimia)
        {
            int result = 0;
            int thirteenNumber = 13;
            char[] rfcHomonimiaCharArray = rfcHomonimia.ToCharArray();
            foreach (char c in rfcHomonimiaCharArray)
            {
                //step 1.- Se asignaran los valores del Anexo III a las letras y números del registro federal de contribuyentes formado a 12 posiciones
                string aux = c.AnexoThree();
                //step 2.- Una vez asignados los valores se aplicara la siguiente forma tomando como base  el factor 13 en orden descendente a cada letra y número del R.F.C. para su multiplicación, de acuerdo a la siguiente formula:
                result += Convert.ToInt32(aux) * thirteenNumber;
                thirteenNumber--;
            }

            //El resultado de la suma se divide entre el factor 11.
            int elevenNumber = 11;
            int residuo = result % elevenNumber;
            string digitVerify = "0";

            if (residuo == 10)
                digitVerify = "A";
            else if (residuo > 0)
            {
                int res = elevenNumber - residuo;
                digitVerify = res == 10 ? "A" : $"{res}";
            }

            return digitVerify;
        }
    }
}
