using System.Text.RegularExpressions;

namespace RfcHomoclave.Middleware.Helpers.RfcHomoclave
{
    public static class RfcHomoclaveHelper
    {
        public static (string alphaPart, string numericPart) SeparateText(this string input)
        {
            // Usamos una expresión regular para separar la parte alfabética y la numérica
            var match = Regex.Match(input, @"^([A-Za-z]+)(\d+.*)$");

            if (match.Success)
            {
                string alphaPart = match.Groups[1].Value;
                string numericPart = match.Groups[2].Value;
                return (alphaPart, numericPart);
            }

            // Si no se encuentra una coincidencia, se devuelve la cadena original como la parte numérica
            return (string.Empty, input);
        }

        private static string[] NotAcceptedNames = {
            "MARIA DEL ", "MARIA DE LOS ", "MARIA ", "JOSE DE ", "JOSE ", "MA. ", "MA ", "M. ", "J. ", "J "
        };

        public static string RemoveCommonNames(this string name)
        {
            foreach (var notAccepted in NotAcceptedNames)
            {
                if (name.StartsWith(notAccepted))
                {
                    name = name.Substring(notAccepted.Length);
                    break;
                }
            }
            return name;
        }

        public static string WordsNotUsed(this string input)
        {
            // Manejo de palabras inconvenientes
            var wordsNotUse = new List<string> {
               "LA","SA DE CV","LOS","Y","SA","CIA","SOC","COOP",
               "A EN P","S EN C","EN","CON","SUS","SC","SCS","THE","AND",
               "CO","MAC","VAN","A","SA DE CV MI","COMPAÑÍA","DE","LA","LAS",
               "MC","VON","DEL","LOS","MI"
            };

            var inputs = input.Split(" ");

            if (inputs.Length > 1)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    var word = wordsNotUse.FirstOrDefault(x => x.Equals(inputs[i]));
                    if (word != null)
                        input = input.Replace(word, "", StringComparison.OrdinalIgnoreCase);
                }
                // Elimina espacios dobles generados tras reemplazar palabras
                //return Regex.Replace(input, @"\s+", "").Trim();
            }

            return input;
        }

        public static string DisadvantagesWords(this string rfc)
        {
            // Manejo de palabras inconvenientes
            var disadvantagesWords = new List<string> {
               "BUEI","BUEY","CACA","CACO","CAGA","CAGO","CAKA","COGE","COJA",
               "COJE","COJI","COJO","CULO","FETO","GUEY","JOTO","KACA","KACO",
               "KAGA","KAGO","KAKA","KULO","MAME","MAMO","MEAR","MEON","MION",
               "MOCO","MULA","PEDA","PEDO","PENE","PUTA","PUTO","QULO","RATA",
               "RUIN","KOGE","KOJO"
            };

            if (disadvantagesWords.Contains(rfc))
                rfc = $"{rfc[..3]}X";

            return rfc;
        }

        public static string RemoveAccents(this string input)
        {
            var accents = new Dictionary<char, char> {
                {'Á', 'A'}, {'É', 'E'}, {'Í', 'I'}, {'Ó', 'O'}, {'Ú', 'U'},
                {'á', 'a'}, {'é', 'e'}, {'í', 'i'}, {'ó', 'o'}, {'ú', 'u'},
            };

            foreach (var accent in accents)
            {
                input = input.Replace(accent.Key, accent.Value);
            }

            ;
            return input;
        }
    }
}
