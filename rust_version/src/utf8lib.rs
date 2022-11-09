//All the functions

/*
utf-8 encoding
0xxx xxxx
110x xxxx 10xx xxxx
1110 xxxx 10xx xxxx 10xx xxxx
1111 0xxx 10xx xxxx 10xx xxxx 10xx xxxx
*/

pub fn check_ascii(x: u8) -> bool {
    if x <= 127 { true }
    else { false }
}

pub fn start_two_bytes(x: u8) -> bool {
    if x >= 192 && x <= 223 { true }
    else { false }
}

pub fn start_three_bytes(x: u8) -> bool {
    if x >= 224 && x <= 239 { true }
    else { false }
}

pub fn start_four_bytes(x: u8) -> bool {
    if x >= 240 && x <= 247 { true }
    else { false }
}

pub fn trailing_byte(x: u8) -> bool {
    if x >= 128 && x <= 191 { true }
    else { false }
}

pub fn first_character(the_char: u8) -> (bool, u8) {

    let latin1: bool = trailing_byte(the_char);
    if latin1 { return (false, 0); }

    let has_two_b: bool = start_two_bytes(the_char);
    if has_two_b { return ( true, 1); }

    let has_three_b: bool = start_three_bytes(the_char);
    if has_three_b { return (true, 2); }

    let has_four_b: bool = start_four_bytes(the_char);
    if has_four_b { return (true, 3); }

    else { return (false, 100); } // if mistake 
}

pub fn next_character(the_char: u8, mut trailing_byte_count: u8) -> (bool, u8) {
    trailing_byte_count -= 1;
    let good_trailing_char: bool = trailing_byte(the_char);
    
    if good_trailing_char {
        return (true, trailing_byte_count);
    }
    else { return (false, trailing_byte_count); }
}

