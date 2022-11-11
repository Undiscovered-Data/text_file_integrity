using System;
public class TheLib

/*
utf-8 encoding
0xxx xxxx
110x xxxx 10xx xxxx
1110 xxxx 10xx xxxx 10xx xxxx
1111 0xxx 10xx xxxx 10xx xxxx 10xx xxxx
*/

{
    public bool check_ascii(int the_char)
    {
        if (the_char <= 127) { return true; }
        else { return false; }
    }

    public bool start_two_bytes(int the_char)
    {
        if (the_char >= 192 && the_char <= 223) { return true; }
        else { return false; }
    }

    public bool start_three_bytes(int the_char)
    {
        if (the_char >= 224 && the_char <= 239) { return true; }
        else { return false; }
    }

    public bool start_four_bytes(int the_char)
    {
        if (the_char >= 240 && the_char <= 247) { return true; }
        else { return false; }
    }

    public bool trailing_byte(int the_char)
    {
        if (the_char >= 128 && the_char <= 191) { return true; }
        else { return false; }
    }

    public Tuple<bool, int> first_character(int the_char)
    {
        TheLib obj = new TheLib();

        bool is_ascii = obj.check_ascii(the_char);
        if (is_ascii) { return new Tuple<bool, int>(true, 0); }

        bool latin1 = obj.trailing_byte(the_char);
        if (latin1) { return new Tuple<bool, int>(false, 0); }

        bool has_two_b = obj.start_two_bytes(the_char);
        if (has_two_b) { return new Tuple<bool, int>(true, 1); }

        bool has_three_b = obj.start_three_bytes(the_char);
        if (has_three_b) { return new Tuple<bool, int>(true, 2); }

        bool has_four_b = obj.start_four_bytes(the_char);
        if (has_four_b) { return new Tuple<bool, int>(true, 3); }

        else { return new Tuple<bool, int>(true, 100); }
    }

    public Tuple<bool, int> next_character(int the_char, int trailing_byte_count)
    {
        trailing_byte_count--;
        bool good_trailing_char = trailing_byte(the_char);

        if (good_trailing_char) { 
            return new Tuple<bool, int>(true, trailing_byte_count);
        }
        else { return new Tuple<bool, int>(false, trailing_byte_count);}
    }
/*
    public static void Main(string[] args)
	{
		TheLib obj = new TheLib();

        System.Console.WriteLine(65);
        System.Console.WriteLine(obj.first_character(65));
        System.Console.WriteLine(130);
        System.Console.WriteLine(obj.first_character(130));
        System.Console.WriteLine(195);
        System.Console.WriteLine(obj.first_character(195));
        System.Console.WriteLine(230);
        System.Console.WriteLine(obj.first_character(230));
        System.Console.WriteLine(244);
        System.Console.WriteLine(obj.first_character(244));

        System.Console.WriteLine("\nChar and count");
        System.Console.WriteLine(obj.next_character(130, 2));
	}
*/
}
