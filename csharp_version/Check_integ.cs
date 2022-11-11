using System;
using System.IO;
  
class GFG {
    public static void Main()
    {
        string path = @"../test.txt";
        byte[] readText = File.ReadAllBytes(path);

        uint trailing_byte_count = 0;
        uint char_count = 0;
        TheLib obj = new TheLib();
        foreach(byte s in readText)
        {
            char_count++;
            if (trailing_byte_count == 0)
            {
                bool good_ascii = obj.check_ascii(s);
                if (good_ascii) { continue; }

                var first_char_return = obj.first_character(s);
                var good_char = first_char_return.Item1;
                var more_chars = first_char_return.Item2;

                if (good_char && more_chars >= 1 && more_chars <= 3)
                {
                    trailing_byte_count = more_chars;
                    continue;
                }

                else if (good_char == false)
                {
                    string a_message = String.Format("{0} ** {1}", s, char_count);
                    Console.WriteLine(a_message);
                }
                else { Console.WriteLine(" Mistake 1 "); }

            }
            else
            {
                var next_char_return = obj.next_character(s, trailing_byte_count);
                var good_char = next_char_return.Item1;
                var more_chars = next_char_return.Item2;
                trailing_byte_count = more_chars;
        
                if (good_char) { continue; }
                else { Console.WriteLine(char_count); }
            }

        }
    }
}
