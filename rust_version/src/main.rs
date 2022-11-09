use utf8lib::{check_ascii, first_character, next_character};
use std::io;
use std::io::Read;
use std::io::BufReader;
use std::fs::File;

fn main() -> io::Result<()> {

    let f = File::open("test.txt")?;
    let mut reader = BufReader::new(f);
    let mut buffer = Vec::new();
    reader.read_to_end(&mut buffer)?;

    let mut the_count: u32 = 0;
    let mut trailing_byte_count: u8 = 0;

    for the_byte in buffer {
        the_count += 1;
        if trailing_byte_count == 0 {
            let good_ascii: bool = check_ascii(the_byte);
            if good_ascii { continue; }

            let (good_char, more_chars) = first_character(the_byte);
            if good_char && more_chars >= 1 && more_chars <= 3 {
                trailing_byte_count = more_chars;
                continue;
            }

            else if good_char == false { 
                println!("{the_byte}, *, {the_count}");
            }

            else { println!(" Mistake 1 "); }
        }
        //println!("Bytes {the_byte}")

        else { 
            let (good_char, more_chars) = next_character(the_byte, trailing_byte_count);
            trailing_byte_count = more_chars;

            if good_char { continue; }

            else { println!("{the_count}"); }
        }
    }
    Ok(())
}
