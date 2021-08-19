using System;
using System.Text;

namespace VideoMenuLibrary.Utility
{
    public static class ConsoleUtility
    {
        public static string GetInput()
        {
            return Console.ReadLine();
        }

        public static int GetInputAsInt()
        {
            int parsed = 0;
            int.TryParse(GetInput(), out parsed);
            return parsed;
        }

        public static void PrintLine(this string text)
        {
            Console.WriteLine(text);
        }

        public static void Print(this string text)
        {
            Console.Write(text);
        }

        public static void PrintLine(this string text, PrefixType prefix = PrefixType.NONE)
        {
            string prefix_text = "";

            switch (prefix)
            {
                case PrefixType.VIDEO_RELEASE_DATE:
                    prefix_text = "[Release Date]";
                    break;

                case PrefixType.VIDEO_STORY_LINE:
                    prefix_text = "[Story Line]";
                    break;

                case PrefixType.VIDEO_TITLE:
                    prefix_text = "[Title]";
                    break;

                case PrefixType.NARRATOR:
                    prefix_text = "[Narrator]";
                    break;
            }
            prefix_text = string.IsNullOrEmpty(prefix_text) ? prefix_text : prefix_text += " ";
            PrintLine(prefix_text + text);
        }

        public static void Print(this string text, PrefixType prefix = PrefixType.NONE)
        {
            string prefix_text = "";

            switch (prefix)
            {
                case PrefixType.VIDEO_RELEASE_DATE:
                    prefix_text = "[Release Date]";
                    break;

                case PrefixType.VIDEO_STORY_LINE:
                    prefix_text = "[Story Line]";
                    break;

                case PrefixType.VIDEO_TITLE:
                    prefix_text = "[Title]";
                    break;

                case PrefixType.NARRATOR:
                    prefix_text = "[Narrator]";
                    break;
            }
            prefix_text = string.IsNullOrEmpty(prefix_text) ? prefix_text : prefix_text += " ";
            Print(prefix_text + text);
        }

        public static string MakeHeader(this string title, int amount, string character = "=")
        {
            StringBuilder sb = new StringBuilder();
            int totalLength = title.Length + amount;
            string header = $"{MakeCopy(character, totalLength) } { title} { MakeCopy(character, totalLength)}";
            sb.AppendLine($"{MakeCopy(character, header.Length)}");
            sb.AppendLine(header);
            sb.AppendLine($"{MakeCopy(character, header.Length)}");
            return sb.ToString();
        }

        public static string MakeCopy(string character, int amount)
        {
            string result = "";
            for (int i = 0; i < amount; i++)
            {
                result += character;
            }
            return result;
        }
    }
}
